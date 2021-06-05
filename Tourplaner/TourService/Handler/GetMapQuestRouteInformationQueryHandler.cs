using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using TourService.Entities;
using TourService.Extensions;
using TourService.Query;
using TourService.Services;

namespace TourService.Handler
{
    public class GetMapQuestRouteInformationQueryHandler : IRequestHandler<GetMapQuestRouteInformationQuery,CustomResponse<MapQuestServiceResponse>>
    {
        private readonly IMapQuestService _mapQuestService;
        private readonly ILogger _logger = Log.ForContext<GetLogsQueryHandler>();

        public GetMapQuestRouteInformationQueryHandler(IMapQuestService mapQuestService)
        {
            _mapQuestService = mapQuestService;
        }

        public async Task<CustomResponse<MapQuestServiceResponse>> Handle(GetMapQuestRouteInformationQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var mapQuestEntity = await _mapQuestService.GetMapQuestResponseForRoute(request.From, request.To, request.Language);
                var imageSource = await _mapQuestService.GetImageSourceForRoute(mapQuestEntity);

                var resp =  new MapQuestServiceResponse()
                {
                    EstimatedDistance = mapQuestEntity.route.distance,
                    ImageSource = imageSource,
                    Directions = mapQuestEntity.ToDirectionsList()
                };
                return CustomResponse.Success<MapQuestServiceResponse>(resp);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return CustomResponse.Error<MapQuestServiceResponse>(400, e.Message);
            }
        }
    }
}