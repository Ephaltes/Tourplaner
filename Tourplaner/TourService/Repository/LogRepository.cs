using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Npgsql;
using Serilog;
using TourService.Entities;
using TourService.Extensions;

namespace TourService.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly NpgsqlConnection _connection;
        public LogRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<LogEntity>> GetAllForRoute(int id)
        {
            Log.Debug($"Get all Log Entries for Route Id: {id}");
            await _connection.OpenAsync();

            var list = new List<LogEntity>();
            
            var sql = "SELECT * FROM Log WHERE route_id=@id";
            using var cmd = new NpgsqlCommand(sql, _connection);
            cmd.Parameters.AddWithValue("id", id);

            var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                list.Add(reader.ToLogEntity());
            }
            
            await _connection.CloseAsync();  
            return list;
        }
        
        public async Task<int> UpSert(LogEntity entity)
        {
            await _connection.OpenAsync();

            var sqlInsert =
                "INSERT INTO Log VALUES(DEFAULT,@StartDate,@EndDate,@Origin,@Destination,@Distance,@Rating,@Note,@MovementMode,@Mood,@BPM,@route_id) ON CONFLICT (id) DO UPDATE SET (startdate,enddate,origin,destination,distance,rating,note,movementmode,mood,bpm,route_id) = (@StartDate,@EndDate,@Origin,@Destination,@Distance,@Rating,@Note,@MovementMode,@Mood,@BPM,@route_id) RETURNING id";

            var sqlUpdate =
                "INSERT INTO Log VALUES(@id,@StartDate,@EndDate,@Origin,@Destination,@Distance,@Rating,@Note,@MovementMode,@Mood,@BPM,@route_id) ON CONFLICT (id) DO UPDATE SET (startdate,enddate,origin,destination,distance,rating,note,movementmode,mood,bpm,route_id) = (@StartDate,@EndDate,@Origin,@Destination,@Distance,@Rating,@Note,@MovementMode,@Mood,@BPM,@route_id) RETURNING id";

            NpgsqlCommand cmd;
            cmd = entity.Id<=0 ? new NpgsqlCommand(sqlInsert, _connection) : new NpgsqlCommand(sqlUpdate, _connection);


            var startdate = entity.StartDate + entity.StartTime;
            var enddate = entity.EndDate + entity.EndTime;
            
            cmd.Parameters.AddWithValue("id", entity.Id);
            cmd.Parameters.AddWithValue("startdate", startdate);
            cmd.Parameters.AddWithValue("enddate", enddate);
            cmd.Parameters.AddWithValue("origin", entity.Origin);
            cmd.Parameters.AddWithValue("destination", entity.Destination);
            cmd.Parameters.AddWithValue("distance", entity.Distance);
            cmd.Parameters.AddWithValue("rating", entity.Rating);
            cmd.Parameters.AddWithValue("note", entity.Note);
            cmd.Parameters.AddWithValue("movementmode", (int) entity.MovementMode);
            cmd.Parameters.AddWithValue("mood",(int) entity.Mood);
            cmd.Parameters.AddWithValue("bpm", entity.BPM);
            cmd.Parameters.AddWithValue("route_id", entity.Route_id);

            return (int) await cmd.ExecuteScalarAsync();
        }
        
        public async Task<bool> Delete(int id)
        {
            await _connection.OpenAsync();
            var sql = "DELETE FROM Log where id=@id";

            var cmd = new NpgsqlCommand(sql, _connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();

            await _connection.CloseAsync();
            return true;
        }
    }
}