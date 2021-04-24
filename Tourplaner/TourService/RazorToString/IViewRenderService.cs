﻿using System.Threading.Tasks;

namespace TourService.RazorToString
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}