using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Npgsql;
using Serilog;
using TourService.Entities;
using TourService.Extensions;

namespace TourService.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly NpgsqlConnection _connection;
        private readonly ILogger _logger = Log.ForContext<RouteRepository>();
        public RouteRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<RouteEntity>> GetAll()
        {
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
            _logger.Debug($"Get Route Entry for Route Id: {id}");
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

        public async Task<int> UpSert(RouteEntity entity)
        {
            await _connection.OpenAsync();

            var sqlInsert =
                "INSERT INTO Route VALUES(DEFAULT,@name,@origin,@destination,@description,@imagename,@directions,@estimateddistance) ON CONFLICT (id) DO UPDATE SET (name,origin,destination,description,imagename,directions,estimateddistance) = (@name,@origin,@destination,@description,@imagename,@directions,@estimateddistance) RETURNING id";

            var sqlUpdate =
                "INSERT INTO Route VALUES(@id,@name,@origin,@destination,@description,@imagename,@directions,@estimateddistance) ON CONFLICT (id) DO UPDATE SET (name,origin,destination,description,imagename,directions,estimateddistance) = (@name,@origin,@destination,@description,@imagename,@directions,@estimateddistance) RETURNING id";

            NpgsqlCommand cmd;
            
            cmd = entity.Id<=0 ? new NpgsqlCommand(sqlInsert, _connection) : new NpgsqlCommand(sqlUpdate, _connection);

            var directions = JsonConvert.SerializeObject(entity.Directions);
            
            cmd.Parameters.AddWithValue("id", entity.Id);
            cmd.Parameters.AddWithValue("name", entity.Name);
            cmd.Parameters.AddWithValue("origin", entity.Origin);
            cmd.Parameters.AddWithValue("destination", entity.Destination);
            cmd.Parameters.AddWithValue("description", entity.Description);
            cmd.Parameters.AddWithValue("imagename", entity.FileName??"");
            cmd.Parameters.AddWithValue("directions", directions);
            cmd.Parameters.AddWithValue("estimateddistance", entity.EstimatedDistance);

            var resp = (int)await cmd.ExecuteScalarAsync();
            
            await _connection.CloseAsync();

            return resp;
        }

        public async Task<bool> Delete(int id)
        {
            await _connection.OpenAsync();
            var sql = "DELETE FROM Route where id=@id";

            var cmd = new NpgsqlCommand(sql, _connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();

            await _connection.CloseAsync();
            return true;
        }
    }
}