using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Accessibility;
using frontend.API;
using frontend.Extensions;
using Newtonsoft.Json;
using Serilog;
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
        
        public double EstimatedDistance { get; set; }
        public Lazy<ObservableCollection<LogModel>> Logs { get; set; } 
        
        private ITourService _service;

        public RouteModel(ITourService service)
        {
            _service = service;
            Logs = new Lazy<ObservableCollection<LogModel>>( () => GetLogsForRoute().Result);
        }
        private async Task<ObservableCollection<LogModel>> GetLogsForRoute()
        {
            Log.Error("GetLogs");
            var entityList = await _service.GetAllLogsForId(Id);
            return new ObservableCollection<LogModel>(entityList.ToModel());
        }

        public bool Contains(string filter)
        {
            var searchTerm = filter.ToLower();
            
            if (Description.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) || 
                Destination.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) ||
                Origin.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) ||
                Name.Contains(searchTerm,StringComparison.OrdinalIgnoreCase) ||
                EstimatedDistance.ToString().Contains(filter)
            ) return true;

            foreach (var model in Logs.Value)
            {
                if (model.Contains(searchTerm))
                    return true;
            }

            return false;
        }
    }
}