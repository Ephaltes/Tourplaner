using System.Collections.Generic;
using MediatR;
using TourService.Entities;

namespace TourService.Query
{
    public class GetAllRoutesQuery : IRequest<CustomResponse<List<RouteEntity>>>
    {
        public bool WithLogs { get; }
        public GetAllRoutesQuery(bool withLogs)
        {
            WithLogs = withLogs;
        }

    }
}