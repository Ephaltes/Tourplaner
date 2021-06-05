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
    public class DeleteLogCommandHandler : IRequestHandler<DeleteLogCommand,CustomResponse<bool>>
    {
        private readonly ILogRepository _logRepository;
        private readonly ILogger _logger = Log.ForContext<DeleteLogCommandHandler>();

        public DeleteLogCommandHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<CustomResponse<bool>> Handle(DeleteLogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Debug($"Delete Log with Id {request.Id}");
                await _logRepository.Delete(request.Id);
                return CustomResponse.Success(true);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return CustomResponse.Error<bool>(400, e.Message);
            }
        }
    }
}