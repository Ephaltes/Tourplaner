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
    }
}