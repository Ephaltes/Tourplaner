using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TourService.Entities;
using TourService.Extensions;
using Utility;

namespace TourService.Services
{
    public class MapQuestService : IMapQuestService
    {
        private readonly string _apikey;
        private readonly IHttpHelper _httpHelper;
        public MapQuestService(string apikey, IHttpHelper httpHelper)
        {
            _apikey = apikey;
            _httpHelper = httpHelper;
        }
        public async Task<MapQuestEntity> GetMapQuestResponseForRoute(string from, string to, string language)
        {
            Dictionary<string, string> routeDictionary = new Dictionary<string, string>()
            {
                {"key", _apikey},
                {"from", from},
                {"to", to},
                {"outFormat", "json"},
                {"unit", "k"},
                {"locale", language},
            };
            var routeQuery = _httpHelper.ParseQueryString(routeDictionary);


            var response = await _httpHelper.ExecuteGet("directions/v2/route?"+routeQuery);

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<MapQuestEntity>(await response.Content.ReadAsStringAsync());

            return null;
        }

        public async Task<byte[]> GetImageSourceForRoute(MapQuestEntity entity)
        {
            Dictionary<string, string> routeDictionary = new Dictionary<string, string>()
            {
                {"key", _apikey},
                {"size", "600,400"},
                {"boundingBox", entity.ToBoundingBoxString()},
                {"format", "png"},
                {"session", entity.route.sessionId},
                {"margin","50"}
            };
            var routeQuery = _httpHelper.ParseQueryString(routeDictionary);
            
            var response = await _httpHelper.ExecuteGet("staticmap/v5/map?"+routeQuery);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsByteArrayAsync();

            return null;
        }
        
        
    }
}