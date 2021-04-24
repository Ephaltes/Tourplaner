using System;
using System.Collections.Generic;
using frontend.API;
using Microsoft.AspNetCore.Routing;
using Serilog;

namespace frontend.Entities
{
    public class RouteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }

        public List<string> Directions { get; set; }
        public Lazy<List<LogEntity>> Logs => new Lazy<List<LogEntity>>(() => GetLogsForRoute(Id));

        private IRouteService _service;

        public RouteEntity(IRouteService service)
        {
            _service = service;
        }


        private static List<LogEntity> GetLogsForRoute(int id)
        {
            var entity = new LogEntity()
            {
                Destination = "destination",
                Distance = 50,
                Id = id,
                Mood = Mood.Bad,
                Note = "",
                Origin = "origin",
                Rating = 5.3,
                EndDate = DateTime.Now.AddDays(1),
                EndTime = new TimeSpan(14, 0, 20),
                MovementMode = MovementMode.Bicycle,
                StartDate = DateTime.Now,
                StartTime = new TimeSpan(12, 0, 0),
                BPM = 230
            };

            var list = new List<LogEntity>();
            list.Add(entity);
            list.Add(entity);
            list.Add(entity);
            list.Add(entity);

            return list;
        }
    }
}