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
        
        #region Route
        public Task<int> CreateRoute(RouteEntity entity);
        public Task<RouteEntity> UpdateRoute(RouteEntity entity);

        public Task<bool> DeleteRoute(int id);
        public Task<List<RouteEntity>> GetAllRoutes();
        public Task<RouteEntity> GetRoute(int id);

        #endregion
        
        #region Log
        public Task<int> CreateLog(LogEntity entity);
        public Task<LogEntity> UpdateLog(LogEntity entity);


        public Task<List<LogEntity>> GetAllLogsForId(int routeId);
        public Task<bool> DeleteLog(int id);
        #endregion
    }
}