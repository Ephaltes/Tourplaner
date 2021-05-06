using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using MediatR;
using Microsoft.AspNetCore.Mvc.Razor;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using Serilog;
using TourService.Entities;
using TourService.Extensions;
using TourService.Query;
using TourService.RazorToString;
using TourService.Repository;

namespace TourService.Handler
{
    public class GeneratePDFQueryHandler: IRequestHandler<GeneratePDFQuery,CustomResponse<byte[]>>
    {

        private readonly IViewRenderService _renderService;
        private readonly IRouteRepository _routeRepository;
        private readonly ILogRepository _logRepository;
        private readonly IFileRepository _fileRepository;
        public GeneratePDFQueryHandler(IViewRenderService renderService, IRouteRepository routeRepository, 
            ILogRepository logRepository, IFileRepository fileRepository)
        {
            _renderService = renderService;
            _routeRepository = routeRepository;
            _logRepository = logRepository;
            _fileRepository = fileRepository;
        }
        public async Task<CustomResponse<byte[]>> Handle(GeneratePDFQuery request, CancellationToken cancellationToken)
        {
            Log.Debug($"Creating PDF for Id: {request.Id}");
            
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions {Headless = true});

            //request.Entity.ImageSource = File.ReadAllBytes(Directory.GetCurrentDirectory()+"/images/placeholder.png");
            var entity = await _routeRepository.Get(request.Id);
            entity.Logs = await _logRepository.GetAllForRoute(request.Id);
            entity.ImageSource = await _fileRepository.ReadFileFromDisk(entity.FileName);
            
            await using var page = await browser.NewPageAsync();
            var body = await _renderService.RenderToStringAsync("~/Template/RouteTemplate.cshtml", entity);
            var header = await _renderService.RenderToStringAsync("~/Template/RouteHeaderTemplate.cshtml", entity);
            var footer = await _renderService.RenderToStringAsync("~/Template/RouteFooterTemplate.cshtml", entity);
            await page.SetContentAsync(body);
            //await page.EmulateMediaTypeAsync(MediaType.Screen);

            PdfOptions options = new PdfOptions
            {
                HeaderTemplate = header,
                FooterTemplate = footer,
                DisplayHeaderFooter = true,
                PrintBackground = true,
                Landscape = true,
                Format = PaperFormat.A4
            };

            options.MarginOptions.Bottom = "2cm";
            options.MarginOptions.Top = "2cm";
            options.MarginOptions.Left = "1cm";
            options.MarginOptions.Right = "1cm";

            await page.PdfAsync(Directory.GetCurrentDirectory() + "/test.pdf",options); //debug code
            var data = await page.PdfDataAsync(options);
            
            Log.Debug($"Created Pdf successfull for ID {request.Id}");            
            return CustomResponse.Success(data);
        }
    }
}