using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Npgsql;
using Serilog;
using TourService.Entities;
using TourService.Extensions;

namespace TourService.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly NpgsqlConnection _connection;
        public RouteRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<RouteEntity>> GetAllRoutes()
        {
            Log.Debug($"Get all Routes");
            await _connection.OpenAsync();

            var list = new List<RouteEntity>();
            
            var sql = "SELECT * FROM Route";
            using var cmd = new NpgsqlCommand(sql, _connection);
            var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                list.Add(reader.ToRouteEntity());
            }
            
            await _connection.CloseAsync();  
            return list;
        }
        
        public async Task<RouteEntity> Get(int id)
        {
            Log.Debug($"Get Route Entry for Route Id: {id}");
            await _connection.OpenAsync();
            RouteEntity entity = null;
            
            var sql = "SELECT * FROM Route where id=@id";
            using var cmd = new NpgsqlCommand(sql, _connection);
            cmd.Parameters.AddWithValue("id", id);
            
            var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                entity = reader.ToRouteEntity();
            }
            await _connection.CloseAsync();  
            return entity;
        }
    }
}