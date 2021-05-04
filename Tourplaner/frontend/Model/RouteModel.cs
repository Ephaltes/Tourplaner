using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using frontend.API;
using frontend.Extensions;
using Newtonsoft.Json;
using TourService.Entities;

namespace frontend.Model
{
    public class RouteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public byte[] ImageSource { get; set; }
        public List<string> Directions { get; set; }
        public Lazy<List<LogModel>> Logs => new Lazy<List<LogModel>>( () => GetLogsForRoute(Id).Result);

        private ITourService _service;

        public RouteModel(ITourService service)
        {
            _service = service;
        }


        private async Task<List<LogModel>> GetLogsForRoute(int id)
        {
            var list = new List<LogModel>();
            var entityList = await _service.GetAllLogsForId(id);
            foreach (var entity in entityList)
            {
                list.Add(entity.ToModel());
            }

            return list;
        }

        public bool Contains(string filter)
        {
            if (Description.Contains(filter.ToLower(),StringComparison.OrdinalIgnoreCase) || 
                Destination.Contains(filter.ToLower(),StringComparison.OrdinalIgnoreCase) ||
                Origin.Contains(filter.ToLower(),StringComparison.OrdinalIgnoreCase) ||
                Name.Contains(filter.ToLower(),StringComparison.OrdinalIgnoreCase)
            ) return true;

            return false;
        }
    }
}