using System.Collections.Generic;
using System.Linq;
using frontend.API;
using frontend.Model;
using Microsoft.AspNetCore.Routing;
using TourService.Entities;

namespace frontend.Extensions
{
    public static class ToModelExtensions
    {
        public static LogModel ToModel(this LogEntity entity)
        {
            return new LogModel()
            {
                Id = entity.Id,
                Destination = entity.Destination,
                Distance = entity.Distance,
                //Duration = model.Duration,
                //Kcal = model.Kcal,
                Mood = entity.Mood,
                Note = entity.Note,
                Origin = entity.Origin,
                Rating = entity.Rating,
                //AvgSpeed = model.AvgSpeed,
                EndDate = entity.EndDate,
                EndTime = entity.EndTime,
                MovementMode = entity.MovementMode,
                StartDate = entity.StartDate,
                StartTime = entity.StartTime,
                BPM = entity.BPM,
                Route_id = entity.Route_id
            };
        }
        
        public static List<LogModel> ToModel(this List<LogEntity> entityList)
        {
            var list = new List<LogModel>();
            foreach (var entity in entityList)
            {
                list.Add(entity.ToModel());
            }
            return list;
        }
        
        
        public static RouteModel ToModel(this RouteEntity entity,ITourService service)
        {
            return new RouteModel(service)
            {
                Id = entity.Id,
                Destination = entity.Destination,
                Origin = entity.Origin,
                Description = entity.Description,
                Directions = entity.Directions,
                Name = entity.Name,
                ImageSource = entity.ImageSource
            };
        }

        public static List<RouteModel> ToModel(this List<RouteEntity> entityList, ITourService service)
        {
            var list = new List<RouteModel>();
            foreach (var entity in entityList)
            {
                list.Add(entity.ToModel(service));
            }

            return list;
        }
    }
}