using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using TourService.Entities;
using TourService.Query;
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
            try
            {
                _logger.Debug("Getting all Routes");
                var resp = await _routeRepository.GetAll();

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
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return CustomResponse.Error<List<RouteEntity>>(400, e.Message);
            }
        }
    }
}