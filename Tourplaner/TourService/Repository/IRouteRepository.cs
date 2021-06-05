using System.Collections.Generic;
using System.Threading.Tasks;
using TourService.Entities;

namespace TourService.Repository
{
    public interface IRouteRepository
    {
        /// <summary>
        /// Gets a specific route
        /// </summary>
        /// <param name="id">id of the route to get</param>
        /// <returns>the route or null if not found</returns>
        public Task<RouteEntity> Get(int id);
        /// <summary>
        /// Get all Route Entries
        /// </summary>
        /// <returns>List of RouteEntity, can be null if no logs found</returns>
        public Task<List<RouteEntity>> GetAll();
        /// <summary>
        /// Creates and Updates a RouteEntry
        /// </summary>
        /// <param name="entity">RouteEntry to update or insert</param>
        /// <returns>id of the RouteEntry or -1 on error</returns>
        public Task<int> UpSert(RouteEntity entity);
        /// <summary>
        /// Deletes an RouteEntry
        /// </summary>
        /// <param name="id">Id of RouteEntry to delete</param>
        /// <returns>true on success else false</returns>
        public Task<bool> Delete(int id);

    }
}