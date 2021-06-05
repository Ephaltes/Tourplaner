using MediatR;
using Microsoft.AspNetCore.Routing;
using TourService.Entities;

namespace TourService.Command
{
    public class CreateRouteCommand : IRequest<CustomResponse<int>>
    {
        public RouteEntity Entity { get; }

        public CreateRouteCommand(RouteEntity entity)
        {
            Entity = entity;
        }
    }
}