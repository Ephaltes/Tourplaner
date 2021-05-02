using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TourService.Entities;

namespace TourService.Query
{
    public class GetRouteQuery: IRequest<CustomResponse<RouteEntity>>
    {
        public int Id { get; }
        public bool WithLogs { get; }

        public GetRouteQuery(int id, bool withLogs)
        {
            Id = id;
            WithLogs = withLogs;
        }
    }
}