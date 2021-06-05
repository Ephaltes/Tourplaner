﻿using MediatR;
using Microsoft.AspNetCore.Routing;
using TourService.Entities;

namespace TourService.Command
{
    public class CreateLogCommand : IRequest<CustomResponse<int>>
    {
        public LogEntity Entity { get; }

        public CreateLogCommand(LogEntity entity)
        {
            Entity = entity;
        }
    }
}