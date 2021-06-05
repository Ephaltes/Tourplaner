using MediatR;
using TourService.Entities;

namespace TourService.Query
{
    public class GenerateStatisticQuery: IRequest<CustomResponse<byte[]>>
    {
    }
}