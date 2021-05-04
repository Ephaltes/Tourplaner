using System;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Routing;
using TourService.Command;
using TourService.Entities;
using TourService.Repository;

namespace TourService.Handler
{
    public class UpdateLogCommandHandler: IRequestHandler<UpdateLogCommand,CustomResponse<LogEntity>>
    {

        private readonly ILogRepository _logRepository;
        private readonly IFileRepository _fileRepository;

        public UpdateLogCommandHandler(ILogRepository logRepository, IFileRepository fileRepository)
        {
            _logRepository = logRepository;
            _fileRepository = fileRepository;
        }

        public async Task<CustomResponse<LogEntity>> Handle(UpdateLogCommand request, CancellationToken cancellationToken)
        {
            var resp = await _logRepository.UpSert(request.Entity);
           return CustomResponse.Success<LogEntity>(request.Entity);
        }
    }
}