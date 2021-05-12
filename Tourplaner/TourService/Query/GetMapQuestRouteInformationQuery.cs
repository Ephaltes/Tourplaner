using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TourService.Entities;

namespace TourService.Query
{
    public class GetMapQuestRouteInformationQuery: IRequest<CustomResponse<MapQuestServiceResponse>>
    {
        public string From { get; }
        public string To { get; }
        public string Language { get; }

        public GetMapQuestRouteInformationQuery( string from, string to, string language)
        {
            From = from;
            To = to;
            Language = language;
        }
    }
}