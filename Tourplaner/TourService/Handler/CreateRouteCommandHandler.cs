﻿using System;
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
    public class CreateRouteCommandHandler: IRequestHandler<CreateRouteCommand,CustomResponse<int>>
    {

        private readonly IRouteRepository _routeRepository;
        private readonly IFileRepository _fileRepository;
        private readonly ILogger _logger = Log.ForContext<CreateRouteCommandHandler>();

        public CreateRouteCommandHandler(IRouteRepository routeRepository, IFileRepository fileRepository)
        {
            _routeRepository = routeRepository;
            _fileRepository = fileRepository;
        }

        public async Task<CustomResponse<int>> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Create Route");
            var resp = await _routeRepository.UpSert(request.Entity);
            request.Entity.Id = resp;
            
            request.Entity.FileName = Sha256Wrapper.Hash(request.Entity.Id.ToString());
            if (!await _fileRepository.SaveFileToDisk(request.Entity.FileName, request.Entity.ImageSource))
                throw new Exception("Error Saving File");
            
            resp = await _routeRepository.UpSert(request.Entity);
            
            _logger.Debug($"Route Created with Id: {resp}");
           return CustomResponse.Success<int>(resp);
        }
    }
}