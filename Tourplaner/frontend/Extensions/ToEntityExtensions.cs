using System.Collections.Generic;
using System.Linq;
using frontend.Model;
using TourService.Entities;

namespace frontend.Extensions
{
    public static class ToEntityExtensions
    {
        public static LogEntity ToEntity(this LogModel model)
        {
            return new LogEntity()
            {
                Id = model.Id,
                Destination = model.Destination,
                Distance = model.Distance,
                //Duration = model.Duration,
                //Kcal = model.Kcal,
                Mood = model.Mood,
                Note = model.Note,
                Origin = model.Origin,
                Rating = model.Rating,
                //AvgSpeed = model.AvgSpeed,
                EndDate = model.EndDate,
                EndTime = model.EndTime,
                MovementMode = model.MovementMode,
                StartDate = model.StartDate,
                StartTime = model.StartTime,
                BPM = model.BPM,
                Route_id = model.Route_id
                
            };
        }
        
        public static List<LogEntity> ToEntity(this List<LogModel> modelList)
        {
            var list = new List<LogEntity>();
            foreach (var model in modelList)
            {
                list.Add(model.ToEntity());
            }
            return list;
        }
        
        
        public static RouteEntity ToEntity(this RouteModel model)
        {
            return new RouteEntity()
            {
                Id = model.Id,
                Destination = model.Destination,
                Origin = model.Origin,
                Description = model.Description,
                Directions = model.Directions,
                Logs =  model.Logs.Value.ToEntity(),
                Name = model.Name,
                ImageSource = model.ImageSource
            };
        }
    }
}