using MediatR;
using TourService.Entities;

namespace TourService.Command
{
    public class UpdateRouteCommand : IRequest<CustomResponse<RouteEntity>>
    {
        public RouteEntity Entity { get; }

        public UpdateRouteCommand(RouteEntity entity)
        {
            Entity = entity;
        }
    }
}