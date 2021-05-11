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

        public DeleteRouteCommandHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<CustomResponse<bool>> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug($"Delete Route with ID: {request.Id}");
            await _routeRepository.Delete(request.Id);
            return CustomResponse.Success(true);
        }
    }
}