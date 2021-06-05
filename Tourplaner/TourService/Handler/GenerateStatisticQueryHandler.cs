using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using Serilog;
using TourService.Entities;
using TourService.Helper;
using TourService.Query;
using TourService.RazorToString;
using TourService.Repository;

namespace TourService.Handler
{
    public class GenerateStatisticQueryHandler: IRequestHandler<GenerateStatisticQuery,CustomResponse<byte[]>>
    {

        private readonly IViewRenderService _renderService;
        private readonly IRouteRepository _routeRepository;
        private readonly ILogRepository _logRepository;
        private readonly ILogger _logger = Log.ForContext<GeneratePDFQueryHandler>();
        public GenerateStatisticQueryHandler(IViewRenderService renderService, IRouteRepository routeRepository, 
            ILogRepository logRepository)
        {
            _renderService = renderService;
            _routeRepository = routeRepository;
            _logRepository = logRepository;
        }
        public async Task<CustomResponse<byte[]>> Handle(GenerateStatisticQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Debug($"Creating Statistic-PDF");
            
                var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
                await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions {Headless = true});

                var helper = new StatisticHelper(_logRepository, _routeRepository);
                var entity = await helper.GetStatistic();
            
                await using var page = await browser.NewPageAsync();
                var body = await _renderService.RenderToStringAsync("~/Template/StatisticTemplate.cshtml", entity);
                var header = await _renderService.RenderToStringAsync("~/Template/StatisticHeaderTemplate.cshtml",null);
                await page.SetContentAsync(body);
                //await page.EmulateMediaTypeAsync(MediaType.Screen);

                PdfOptions options = new PdfOptions
                {
                    HeaderTemplate = header,
                    DisplayHeaderFooter = true,
                    PrintBackground = true,
                    Landscape = true,
                    Format = PaperFormat.A4,
                };

                options.MarginOptions.Bottom = "2cm";
                options.MarginOptions.Top = "2cm";
                options.MarginOptions.Left = "1cm";
                options.MarginOptions.Right = "1cm";

                await page.PdfAsync(Directory.GetCurrentDirectory() + "/test2.pdf",options); //debug code
                var data = await page.PdfDataAsync(options);
            
                _logger.Debug($"Created Statistic-Pdf successfull");            
                return CustomResponse.Success(data);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return CustomResponse.Error<byte[]>(400, e.Message);
            }
        }
    }
}