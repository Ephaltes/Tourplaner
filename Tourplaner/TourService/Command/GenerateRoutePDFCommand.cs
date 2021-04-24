using MediatR;
using TourService.Entities;

namespace TourService.Command
{
    public class GenerateRoutePDFCommand : IRequest<CustomResponse<byte[]>>
    {
        public RouteEntity Entity { get; set; }
    }
}