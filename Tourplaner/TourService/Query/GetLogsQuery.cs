using System.Collections.Generic;
using MediatR;
using TourService.Entities;

namespace TourService.Query
{
    public class GetLogsQuery: IRequest<CustomResponse<List<LogEntity>>>
    {
        public int Id { get; set; }

        public GetLogsQuery(int id)
        {
            Id = id;
        }
    }
}