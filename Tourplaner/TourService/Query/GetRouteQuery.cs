using MediatR;
using TourService.Entities;

namespace TourService.Query
{
    public class GetRouteQuery: IRequest<CustomResponse<RouteEntity>>
    {
        public int Id { get; set; }
        public bool WithLogs { get; }

        public GetRouteQuery(int id, bool withLogs)
        {
            Id = id;
            WithLogs = withLogs;
        }
    }
}