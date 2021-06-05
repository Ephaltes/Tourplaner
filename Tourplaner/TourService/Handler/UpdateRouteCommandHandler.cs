using System;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Routing;
using Serilog;
using TourService.Command;
using TourService.Entities;
using TourService.Repository;

namespace TourService.Handler
{
    public class UpdateRouteCommandHandler: IRequestHandler<UpdateRouteCommand,CustomResponse<RouteEntity>>
    {

        private readonly IRouteRepository _routeRepository;
        private readonly IFileRepository _fileRepository;
        private readonly ILogger _logger = Log.ForContext<UpdateRouteCommandHandler>();

        public UpdateRouteCommandHandler(IRouteRepository routeRepository, IFileRepository fileRepository)
        {
            _routeRepository = routeRepository;
            _fileRepository = fileRepository;
        }

        public async Task<CustomResponse<RouteEntity>> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                _logger.Debug($"Update Route ID: {request.Entity.Id}");
            
                request.Entity.FileName = Sha256Wrapper.Hash(request.Entity.Id.ToString());
                if (!await _fileRepository.SaveFileToDisk(request.Entity.FileName, request.Entity.ImageSource))
                    throw new Exception("Error Saving File");
            
                var resp = await _routeRepository.UpSert(request.Entity);
            
                return CustomResponse.Success<RouteEntity>(request.Entity);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return CustomResponse.Error<RouteEntity>(400, e.Message);
            }
        }
    }
}