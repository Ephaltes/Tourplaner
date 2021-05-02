﻿using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TourService.Entities;

namespace TourService.Query
{
    public class GetLogsQuery: IRequest<CustomResponse<List<LogEntity>>>
    {
        public int Id { get; }

        public GetLogsQuery(int id)
        {
            Id = id;
        }
    }
}