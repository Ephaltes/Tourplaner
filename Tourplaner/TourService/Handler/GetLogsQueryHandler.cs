using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using MediatR;
using Microsoft.AspNetCore.Mvc.Razor;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using Serilog;
using TourService.Entities;
using TourService.Extensions;
using TourService.Query;
using TourService.RazorToString;
using TourService.Repository;

namespace TourService.Handler
{
    public class GetLogsQueryHandler: IRequestHandler<GetLogsQuery,CustomResponse<List<LogEntity>>>
    {

        private readonly ILogRepository _logRepository;
        public GetLogsQueryHandler( ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<CustomResponse<List<LogEntity>>> Handle(GetLogsQuery request, CancellationToken cancellationToken)
        {
            Log.Debug($"Get all Log from Route ID: {request.Id}");
            var resp = await _logRepository.GetAllForRoute(request.Id);
            return CustomResponse.Success(resp);
        }
    }
}