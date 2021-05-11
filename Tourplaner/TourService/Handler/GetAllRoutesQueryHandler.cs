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
    public class GetAllRoutesQueryHandler : IRequestHandler<GetAllRoutesQuery, CustomResponse<List<RouteEntity>>>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ILogRepository _logRepository;
        private readonly IFileRepository _fileRepository;
        private readonly ILogger _logger = Log.ForContext<GetAllRoutesQueryHandler>();

        public GetAllRoutesQueryHandler(IRouteRepository routeRepository, ILogRepository logRepository,
            IFileRepository fileRepository)
        {
            _routeRepository = routeRepository;
            _logRepository = logRepository;
            _fileRepository = fileRepository;
        }

        public async Task<CustomResponse<List<RouteEntity>>> Handle(GetAllRoutesQuery request,
            CancellationToken cancellationToken)
        {
            _logger.Debug("Getting all Routes");
            var resp = await _routeRepository.GetAllRoutes();

            foreach (var entity in resp)
            {
                entity.ImageSource = await _fileRepository.ReadFileFromDisk(entity.FileName);

                if (request.WithLogs)
                {
                    entity.Logs = await _logRepository.GetAllForRoute(entity.Id);
                }
            }

            return CustomResponse.Success(resp);
        }
    }
}