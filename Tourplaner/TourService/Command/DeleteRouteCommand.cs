using System;
using MediatR;
using TourService.Entities;

namespace TourService.Command
{
    public class DeleteRouteCommand : IRequest<CustomResponse<bool>>
    {
        public int Id { get; }

        public DeleteRouteCommand(int id)
        {
            Id = id;
        }
    }
}