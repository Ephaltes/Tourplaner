using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using MediatR;
using Microsoft.AspNetCore.Mvc.Razor;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using TourService.Command;
using TourService.Entities;
using TourService.Extensions;
using TourService.RazorToString;

namespace TourService.Handler
{
    public class GenerateRoutePDFHandler: IRequestHandler<GenerateRoutePDFCommand,CustomResponse<byte[]>>
    {

        private IViewRenderService _renderService;

        public GenerateRoutePDFHandler(IViewRenderService renderService)
        {
            _renderService = renderService;
        }
        public async Task<CustomResponse<byte[]>> Handle(GenerateRoutePDFCommand request, CancellationToken cancellationToken)
        {
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions {Headless = true});

            request.Entity.ImageSource = File.ReadAllBytes(Directory.GetCurrentDirectory()+"/images/placeholder.png");
            
            await using var page = await browser.NewPageAsync();
            var test = await _renderService.RenderToStringAsync("~/Template/RouteTemplate.cshtml", request.Entity);
            var header = await _renderService.RenderToStringAsync("~/Template/RouteHeaderTemplate.cshtml", request.Entity);
            var footer = await _renderService.RenderToStringAsync("~/Template/RouteFooterTemplate.cshtml", request.Entity);
            await page.SetContentAsync(test);
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

            await page.PdfAsync(Directory.GetCurrentDirectory() + "/test.pdf",options);
            var data = await page.PdfDataAsync();
            
            
            return CustomResponse.Success<byte[]>(null);
        }
    }
}