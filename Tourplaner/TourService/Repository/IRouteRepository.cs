using System.Collections.Generic;
using System.Threading.Tasks;
using TourService.Entities;

namespace TourService.Repository
{
    public interface IRouteRepository
    {
        public Task<RouteEntity> Get(int id);
        public Task<List<RouteEntity>> GetAllRoutes();
        public Task<int> UpSert(RouteEntity entity);
    }
}