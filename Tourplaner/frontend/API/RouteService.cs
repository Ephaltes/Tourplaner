﻿using System;
using System.IO;
using System.Threading.Tasks;
using frontend.Commands.Route;
using frontend.Entities;
using Newtonsoft.Json;
using RestWebservice_RemoteCompiling.Helpers;
using TourService.Command;
using TourService.Entities;

namespace frontend.API
{
    public class RouteService : IRouteService
    {
        private readonly IHttpHelper _httpHelper;
        public RouteService(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async Task<byte[]> GetRouteImage(string origin, string destination)
        {
            return await File.ReadAllBytesAsync(Directory.GetCurrentDirectory()+"/images/placeholder.png");
        }

        public async Task<byte[]> GeneratePDF(RouteEntity entity)
        {
            GenerateRoutePDFCommand data = new GenerateRoutePDFCommand() {Entity = entity};
            var responseMessage = await _httpHelper.ExecutePost("Tour", data);
           if (!responseMessage.IsSuccessStatusCode)
               return null;

           var response = JsonConvert.DeserializeObject<ResponseObject>(await responseMessage.Content.ReadAsStringAsync());
           
           if (response == null || response.data==null)
               return null;
           
           return Convert.FromBase64String(response.data.ToString());
        }
    }
}