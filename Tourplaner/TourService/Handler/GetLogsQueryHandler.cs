using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using TourService.Entities;
using TourService.Query;
using TourService.Repository;

namespace TourService.Handler
{
    public class GetLogsQueryHandler: IRequestHandler<GetLogsQuery,CustomResponse<List<LogEntity>>>
    {

        private readonly ILogRepository _logRepository;
        private readonly ILogger _logger = Log.ForContext<GetLogsQueryHandler>();
        public GetLogsQueryHandler( ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<CustomResponse<List<LogEntity>>> Handle(GetLogsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Debug($"Get all Log from Route ID: {request.Id}");
                var resp = await _logRepository.GetAllForRoute(request.Id);
                return CustomResponse.Success(resp);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return CustomResponse.Error<List<LogEntity>>(400, e.Message);
            }
        }
    }
}