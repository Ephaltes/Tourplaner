using MediatR;
using Microsoft.AspNetCore.Routing;
using TourService.Entities;

namespace TourService.Command
{
    public class UpSertRouteCommand : IRequest<CustomResponse<int>>
    {
        public RouteEntity Entity { get; }

        public UpSertRouteCommand(RouteEntity entity)
        {
            Entity = entity;
        }
    }
}