using MediatR;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TourService.Entities;

namespace TourService.Query
{
    public class GenerateStatisticQuery: IRequest<CustomResponse<byte[]>>
    {
    }
}