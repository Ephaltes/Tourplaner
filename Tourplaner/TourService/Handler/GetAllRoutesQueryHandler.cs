using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using MediatR;
using Microsoft.AspNetCore.Mvc.Razor;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using TourService.Entities;
using TourService.Extensions;
using TourService.Query;
using TourService.RazorToString;
using TourService.Repository;

namespace TourService.Handler
{
    public class GetAllRoutesQueryHandler: IRequestHandler<GetAllRoutesQuery,CustomResponse<List<RouteEntity>>>
    {

        private readonly IRouteRepository _routeRepository;
        private readonly ILogRepository _logRepository;
        public GetAllRoutesQueryHandler(IRouteRepository routeRepository, ILogRepository logRepository)
        {
            _routeRepository = routeRepository;
            _logRepository = logRepository;
        }
        public async Task<CustomResponse<List<RouteEntity>>> Handle(GetAllRoutesQuery request, CancellationToken cancellationToken)
        {
            var resp =  await _routeRepository.GetAllRoutes();

            if (request.WithLogs)
            {
                foreach (var entity in resp)
                {
                    entity.Logs = await _logRepository.GetAllForRoute(entity.Id);
                }  
            }
            return CustomResponse.Success(resp);
        }
    }
}