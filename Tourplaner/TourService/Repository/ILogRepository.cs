using System.Collections.Generic;
using System.Threading.Tasks;
using TourService.Entities;

namespace TourService.Repository
{
    public interface ILogRepository
    {
        /// <summary>
        /// Gets all Logs entry for a specific route
        /// </summary>
        /// <param name="id">specific route id</param>
        /// <returns>List of LogEntity, can be null if no logs found</returns>
        public Task<List<LogEntity>> GetAllForRoute(int id);
        /// <summary>
        /// Get all Log Entries over all routes
        /// </summary>
        /// <returns>List of LogEntity, can be null if no logs found</returns>
        public Task<List<LogEntity>> GetAll();
        /// <summary>
        /// Creates and Updates a LogEntry
        /// </summary>
        /// <param name="entity">LogEntity to update or insert</param>
        /// <returns>id of the LogEntry or -1 on error</returns>
        public Task<int> UpSert(LogEntity entity);
        /// <summary>
        /// Deletes an Log Entry
        /// </summary>
        /// <param name="id">Id of LogEntry to delete</param>
        /// <returns>true on success else false</returns>
        public Task<bool> Delete(int id);

    }
}