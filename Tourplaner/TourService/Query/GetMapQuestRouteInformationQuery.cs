using MediatR;
using TourService.Entities;

namespace TourService.Query
{
    public class GetMapQuestRouteInformationQuery: IRequest<CustomResponse<MapQuestServiceResponse>>
    {
        public string From { get; set; }
        public string To { get;set; }
        public string Language { get;set; }

        public GetMapQuestRouteInformationQuery( string from, string to, string language)
        {
            From = from;
            To = to;
            Language = language;
        }
    }
}