using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TourService.Command;
using TourService.Entities;
using TourService.Repository;

namespace TourService.Handler
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand,CustomResponse<bool>>
    {
        private readonly IRouteRepository _routeRepository;

        public DeleteRouteCommandHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<CustomResponse<bool>> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            await _routeRepository.Delete(request.Id);
            return CustomResponse.Success(true);
        }
    }
}