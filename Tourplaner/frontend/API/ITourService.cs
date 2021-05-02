using System.Collections.Generic;
using System.Threading.Tasks;
using frontend.Model;
using Microsoft.AspNetCore.Routing;
using TourService.Entities;

namespace frontend.API
{
    public interface ITourService
    {
        public Task<byte[]> GetRouteImage(string origin, string destination);
        public Task<byte[]> GeneratePDF(int id);
        public Task<int> UpSertRoute(RouteEntity entity);
        public Task<bool> DeleteRoute(int id);
        public Task<List<RouteEntity>> GetAllRoutes();
        public Task<RouteEntity> GetRoute(int id);
        public Task<List<LogEntity>> GetAllLogsForId(int routeId);

    }
}