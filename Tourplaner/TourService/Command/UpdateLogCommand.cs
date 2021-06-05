using MediatR;
using TourService.Entities;

namespace TourService.Command
{
    public class UpdateLogCommand : IRequest<CustomResponse<LogEntity>>
    {
        public LogEntity Entity { get; }

        public UpdateLogCommand(LogEntity entity)
        {
            Entity = entity;
        }
    }
}