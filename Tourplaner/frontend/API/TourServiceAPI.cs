using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using frontend.Commands.Route;
using frontend.Entities;
using frontend.Extensions;
using frontend.Model;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestWebservice_RemoteCompiling.Helpers;
using Serilog;
using TourService.Command;
using TourService.Entities;
using CreateLogCommand = TourService.Command.CreateLogCommand;
using CreateRouteCommand = TourService.Command.CreateRouteCommand;
using UpdateLogCommand = TourService.Command.UpdateLogCommand;
using UpdateRouteCommand = TourService.Command.UpdateRouteCommand;

namespace frontend.API
{
    public class TourServiceAPI : ITourService
    {
        private readonly IHttpHelper _httpHelper;
        private readonly ILogger _logger = Log.ForContext<TourServiceAPI>();

        public TourServiceAPI(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async Task<byte[]> GetRouteImage(string origin, string destination)
        {
            return await File.ReadAllBytesAsync(Directory.GetCurrentDirectory() + "/images/placeholder.png");
        }

        public async Task<byte[]> GeneratePDF(int id)
        {
            var responseMessage = await _httpHelper.ExecuteGet($"RoutePdf/{id}");
            if (!responseMessage.IsSuccessStatusCode)
                return null;

            var response =
                JsonConvert.DeserializeObject<ResponseObject>(await responseMessage.Content.ReadAsStringAsync());

            if (response == null || response.data == null)
                return null;

            return Convert.FromBase64String(response.data.ToString());
        }

        #region Route
        public async Task<int> CreateRoute(RouteEntity entity)
        {
            CreateRouteCommand cmd = new CreateRouteCommand(entity);
            var responseMessage = await _httpHelper.ExecutePost("Route", cmd);
            if (!responseMessage.IsSuccessStatusCode)
                return -1;

            var response =
                JsonConvert.DeserializeObject<ResponseObject>(await responseMessage.Content.ReadAsStringAsync());

            if (response == null || response.data == null)
                return 0;

            return Convert.ToInt32(response.data);
        }
        
        public async Task<RouteEntity> UpdateRoute(RouteEntity entity)
        {
            UpdateRouteCommand cmd = new UpdateRouteCommand(entity);
            var responseMessage = await _httpHelper.ExecutePut("Route", cmd);
            if (!responseMessage.IsSuccessStatusCode)
                return null;

            var response =
                JsonConvert.DeserializeObject<ResponseObject>(await responseMessage.Content.ReadAsStringAsync());

            if (response == null || response.data == null)
                return null;

            return JsonConvert.DeserializeObject<RouteEntity>(response.data.ToString());
        }
        public async Task<bool> DeleteRoute(int id)
        {
            var responseMessage = await _httpHelper.ExecuteDelete($"Route/{id}");

            if (!responseMessage.IsSuccessStatusCode)
                return false;

            return true;
        }
        public async Task<List<RouteEntity>> GetAllRoutes()
        {
            var responseMessage = await _httpHelper.ExecuteGet("Route");
            if (!responseMessage.IsSuccessStatusCode)
                return new List<RouteEntity>();

            var content = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseObject>(content);

            if (response == null || response.data == null)
                return new List<RouteEntity>();

            return ((JArray) response.data).ToObject<List<RouteEntity>>();
            //return JsonConvert.DeserializeObject<List<RouteEntity>>((JArray) response.data);
        }
        public async Task<RouteEntity> GetRoute(int id)
        {
            var responseMessage = await _httpHelper.ExecuteGet($"Route/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                _logger.Warning(responseMessage.ReasonPhrase);
                return null;
            }

            var response =
                JsonConvert.DeserializeObject<ResponseObject>(await responseMessage.Content.ReadAsStringAsync());

            if (response == null || response.data == null)
            {
                _logger.Warning(response.errors.ToString());
                return null;
            }

            return JsonConvert.DeserializeObject<RouteEntity>((string) response.data);
        }
        #endregion
        
      #region Log
        public async Task<int> CreateLog(LogEntity entity)
        {
            CreateLogCommand cmd = new CreateLogCommand(entity);
            var responseMessage = await _httpHelper.ExecutePost("Log", cmd);
            if (!responseMessage.IsSuccessStatusCode)
                return -1;

            var response =
                JsonConvert.DeserializeObject<ResponseObject>(await responseMessage.Content.ReadAsStringAsync());

            if (response == null || response.data == null)
                return 0;

            return Convert.ToInt32(response.data);
        }
        
        public async Task<LogEntity> UpdateLog(LogEntity entity)
        {
            UpdateLogCommand cmd = new UpdateLogCommand(entity);
            var responseMessage = await _httpHelper.ExecutePut("Route", cmd);
            if (!responseMessage.IsSuccessStatusCode)
                return null;

            var response =
                JsonConvert.DeserializeObject<ResponseObject>(await responseMessage.Content.ReadAsStringAsync());

            if (response == null || response.data == null)
                return null;

            return JsonConvert.DeserializeObject<LogEntity>(response.data.ToString());
        }

        public async Task<bool> DeleteLog(int id)
        {
            var responseMessage = await _httpHelper.ExecuteDelete($"Log/{id}");

            if (!responseMessage.IsSuccessStatusCode)
                return false;

            return true;
        }
        public async Task<List<LogEntity>> GetAllLogsForId(int routeId)
        {
            var responseMessage = await _httpHelper.ExecuteGet($"Log/{routeId}");
            if (!responseMessage.IsSuccessStatusCode)
                return new List<LogEntity>();

            var content = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseObject>(content);

            if (response == null || response.data == null)
                return new List<LogEntity>();

            return ((JArray) response.data).ToObject<List<LogEntity>>();
        }
        #endregion
    }
}