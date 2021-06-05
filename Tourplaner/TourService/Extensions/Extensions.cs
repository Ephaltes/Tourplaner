using System;
using System.Collections.Generic;
using System.Globalization;
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
            entity.Description = reader.IsDBNull(reader.GetOrdinal("description"))? "" : reader.GetString(reader.GetOrdinal("description"));
            entity.EstimatedDistance = reader.IsDBNull(reader.GetOrdinal("estimateddistance"))? 0 : reader.GetDouble(reader.GetOrdinal("estimateddistance"));
            var filename = reader.IsDBNull(reader.GetOrdinal("imagename"))? "" : reader.GetString(reader.GetOrdinal("imagename"));
            entity.FileName = filename;
            var txt = reader.IsDBNull(reader.GetOrdinal("directions"))? "" : reader.GetString(reader.GetOrdinal("directions"));
            entity.Directions = string.IsNullOrWhiteSpace(txt)? new List<string>(): JsonConvert.DeserializeObject<List<string>>(txt);

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
            entity.Note = reader.IsDBNull(reader.GetOrdinal("note"))? "" : reader.GetString(reader.GetOrdinal("note"));
            entity.MovementMode = (MovementMode) reader.GetInt32(reader.GetOrdinal("movementmode"));
            entity.Mood = (Mood) reader.GetInt32(reader.GetOrdinal("mood"));
            entity.BPM = reader.IsDBNull(reader.GetOrdinal("bpm"))? 0 : reader.GetInt32(reader.GetOrdinal("bpm"));
            entity.Route_id = reader.GetInt32(reader.GetOrdinal("route_id"));

            entity.StartTime = entity.StartDate.TimeOfDay;
            entity.EndTime = entity.EndDate.TimeOfDay;

            return entity;
        }

        private static NumberFormatInfo nfi = new NumberFormatInfo() {NumberDecimalSeparator = "."};

        public static string ToBoundingBoxString(this MapQuestEntity entity)
        {
            return
                $"{entity.route.boundingBox.ul.lat.ToString(nfi)}," +
                $"{entity.route.boundingBox.ul.lng.ToString(nfi)}," +
                $"{entity.route.boundingBox.lr.lat.ToString(nfi)}," +
                $"{entity.route.boundingBox.lr.lng.ToString(nfi)}";
        }

        public static List<string> ToDirectionsList(this MapQuestEntity entity)
        {
            if (entity == null)
                return null;

            var list = new List<string>();
            var leg = entity.route.legs[0];


            list.Add(leg.origNarrative);

            foreach (var maneuver in leg.maneuvers)
            {
                list.Add(maneuver.narrative);
            }

            return list;
        }
    }
}