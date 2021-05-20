using System;
using System.Collections.Generic;
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
    public class GetRouteQueryHandler : IRequestHandler<GetRouteQuery, CustomResponse<RouteEntity>>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ILogRepository _logRepository;
        private readonly IFileRepository _fileRepository;
        private readonly ILogger _logger = Log.ForContext<GetRouteQueryHandler>();

        public GetRouteQueryHandler(IRouteRepository routeRepository, ILogRepository logRepository,
            IFileRepository fileRepository)
        {
            _routeRepository = routeRepository;
            _logRepository = logRepository;
            _fileRepository = fileRepository;
        }

        public async Task<CustomResponse<RouteEntity>> Handle(GetRouteQuery request,
            CancellationToken cancellationToken)
        {
            
            try
            {
                _logger.Debug($"Get Route Id : {request.Id}");
                var resp = await _routeRepository.Get(request.Id);
                resp.ImageSource = await _fileRepository.ReadFileFromDisk(resp.FileName);

                if (request.WithLogs)
                    resp.Logs = await _logRepository.GetAllForRoute(request.Id);


                return CustomResponse.Success(resp);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return CustomResponse.Error<RouteEntity>(400, e.Message);
            }
           
        }
    }
}