using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using TourService.Entities;

namespace TourService.Extensions
{
    public static class Extensions
    {
        public static IActionResult ToResponse(this CustomResponse response)
        {
            if (!response.IsSuccess)
                return new ObjectResult(new { response.ErrorMessage }) { StatusCode = response.StatusCode };

            if (response.HasData)
                return new ObjectResult(new { Data = response.GetData() }) { StatusCode = response.StatusCode };

            return new StatusCodeResult(response.StatusCode);
        }

        public static string ToBase64(this byte[] bytes)
        {
            return $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
        }
    }
}