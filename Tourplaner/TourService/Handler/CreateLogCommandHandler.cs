using System;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using TourService.Command;
using TourService.Entities;
using TourService.Repository;

namespace TourService.Handler
{
    public class CreateLogCommandHandler: IRequestHandler<CreateLogCommand,CustomResponse<int>>
    {

        private readonly ILogRepository _logRepository;
        private readonly ILogger _logger = Log.ForContext<CreateLogCommandHandler>();

        public CreateLogCommandHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<CustomResponse<int>> Handle(CreateLogCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug($"Create Log");
            request.Entity.Id = 0;
            var resp = await _logRepository.UpSert(request.Entity);
            _logger.Debug($"Log created with ID: {resp}");
           return CustomResponse.Success<int>(resp);
        }
    }
}