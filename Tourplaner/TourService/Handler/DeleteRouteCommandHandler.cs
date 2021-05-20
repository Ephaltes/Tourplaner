using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using TourService.Command;
using TourService.Entities;
using TourService.Repository;

namespace TourService.Handler
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand,CustomResponse<bool>>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ILogger _logger = Log.ForContext<DeleteRouteCommandHandler>();
        private readonly IFileRepository _fileRepository;

        public DeleteRouteCommandHandler(IRouteRepository routeRepository, IFileRepository fileRepository)
        {
            _routeRepository = routeRepository;
            _fileRepository = fileRepository;
        }

        public async Task<CustomResponse<bool>> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                _logger.Debug($"Delete Route with ID: {request.Id}");
                var entity = await _routeRepository.Get(request.Id);
                await _fileRepository.DeleteFile(entity.FileName);
                await _routeRepository.Delete(request.Id);
                return CustomResponse.Success(true);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return CustomResponse.Error<bool>(400, e.Message);
            }
        }
    }
}