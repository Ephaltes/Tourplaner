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
    public class GetRouteQueryHandler: IRequestHandler<GetRouteQuery,CustomResponse<RouteEntity>>
    {

        private readonly IRouteRepository _routeRepository;
        private readonly ILogRepository _logRepository;
        public GetRouteQueryHandler(IRouteRepository routeRepository, ILogRepository logRepository)
        {
            _routeRepository = routeRepository;
            _logRepository = logRepository;
        }
        public async Task<CustomResponse<RouteEntity>> Handle(GetRouteQuery request, CancellationToken cancellationToken)
        {
            var resp =  await _routeRepository.Get(request.Id);

            if (request.WithLogs)
                resp.Logs = await _logRepository.GetAllForRoute(request.Id);
            
            return CustomResponse.Success(resp);
        }
    }
}