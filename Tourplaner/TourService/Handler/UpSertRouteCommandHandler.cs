using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TourService.Command;
using TourService.Entities;
using TourService.Repository;

namespace TourService.Handler
{
    public class UpSertRouteCommandHandler: IRequestHandler<UpSertRouteCommand,CustomResponse<int>>
    {

        private readonly IRouteRepository _routeRepository;

        public UpSertRouteCommandHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<CustomResponse<int>> Handle(UpSertRouteCommand request, CancellationToken cancellationToken)
        {
           var resp = await _routeRepository.UpSert(request.Entity);
           return CustomResponse.Success<int>(resp);
        }
    }
}