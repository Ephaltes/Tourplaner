using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using TourService.Command;
using TourService.Entities;
using TourService.Repository;

namespace TourService.Handler
{
    public class UpdateLogCommandHandler: IRequestHandler<UpdateLogCommand,CustomResponse<LogEntity>>
    {

        private readonly ILogRepository _logRepository;
        private readonly ILogger _logger = Log.ForContext<UpdateLogCommandHandler>();

        public UpdateLogCommandHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<CustomResponse<LogEntity>> Handle(UpdateLogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Debug($"Update Log ID: {request.Entity.Id}");
                await _logRepository.UpSert(request.Entity);
                return CustomResponse.Success<LogEntity>(request.Entity);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return CustomResponse.Error<LogEntity>(400, e.Message);
            }
        }
    }
}