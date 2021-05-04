using System;
using MediatR;
using TourService.Entities;

namespace TourService.Command
{
    public class DeleteLogCommand : IRequest<CustomResponse<bool>>
    {
        public int Id { get; }

        public DeleteLogCommand(int id)
        {
            Id = id;
        }
    }
}