using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using TourService.Entities;

namespace TourService.Extensions
{
    public static class Extensions
    {
        public static IActionResult ToResponse(this CustomResponse response)
        {
            if (!response.IsSuccess)
                return new ObjectResult(new {response.ErrorMessage}) {StatusCode = response.StatusCode};

            if (response.HasData)
                return new ObjectResult(new {Data = response.GetData()}) {StatusCode = response.StatusCode};

            return new StatusCodeResult(response.StatusCode);
        }

        public static string ToBase64(this byte[] bytes)
        {
            return $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
        }

        public static RouteEntity ToRouteEntity(this NpgsqlDataReader reader)
        {
            var entity = new RouteEntity();

            entity.Id = reader.GetInt32(reader.GetOrdinal("id"));
            entity.Name = reader.GetString(reader.GetOrdinal("name"));
            entity.Origin = reader.GetString(reader.GetOrdinal("origin"));
            entity.Destination = reader.GetString(reader.GetOrdinal("destination"));
            entity.Description = reader.GetString(reader.GetOrdinal("description"));
            var path = reader.GetString(reader.GetOrdinal("imagename"));
            var fullpath = Directory.GetCurrentDirectory() + $"/images/{path}";
            if (FileExists(fullpath))
                entity.ImageSource = File.ReadAllBytes(fullpath);
            entity.Directions = new List<string>();
            //JsonConvert.DeserializeObject<List<string>>(reader.GetString(reader.GetOrdinal("directions")));

            return entity;
        }

        public static LogEntity ToLogEntity(this NpgsqlDataReader reader)
        {
            var entity = new LogEntity();
            entity.Id = reader.GetInt32(reader.GetOrdinal("id"));
            entity.StartDate = reader.GetDateTime(reader.GetOrdinal("startdate"));
            entity.EndDate = reader.GetDateTime(reader.GetOrdinal("enddate"));
            entity.Origin = reader.GetString(reader.GetOrdinal("origin"));
            entity.Destination = reader.GetString(reader.GetOrdinal("destination"));
            entity.Distance = reader.GetDouble(reader.GetOrdinal("distance"));
            entity.Rating = reader.GetDouble(reader.GetOrdinal("rating"));
            entity.Note = reader.GetString(reader.GetOrdinal("note"));
            entity.MovementMode = (MovementMode) reader.GetInt32(reader.GetOrdinal("movementmode"));
            entity.Mood = (Mood) reader.GetInt32(reader.GetOrdinal("mood"));
            entity.BPM = reader.GetInt32(reader.GetOrdinal("bpm"));
            //entity.Duration = reader.GetTimeSpan(reader.GetOrdinal("duration"));
            //entity.AvgSpeed = reader.GetDouble(reader.GetOrdinal("avgspeed"));
            //entity.Kcal = reader.GetInt32(reader.GetOrdinal("kcal"));
            
            entity.StartTime = entity.StartDate.TimeOfDay;
            entity.EndTime = entity.EndDate.TimeOfDay;

            return entity;
        }

        private static bool FileExists(string path)
        {
            return File.Exists(path);
        }
    }
}