using System.Collections.Generic;
using System.Threading.Tasks;
using frontend.Model;
using Microsoft.AspNetCore.Routing;
using TourService.Entities;

namespace frontend.API
{
    /// <summary>
    /// Interface to interact with the backend REST Service
    /// </summary>
    public interface ITourService
    {
        /// <summary>
        /// Gets the EstimatedDistance, Directions and Image from the MapQuest API
        /// </summary>
        /// <param name="origin">Starting Point</param>
        /// <param name="destination">End Point</param>
        /// <returns>MapQuestServiceResponse or null if no route found</returns>
        public Task<MapQuestServiceResponse> GetRouteInformation(string origin, string destination);

        /// <summary>
        /// Generates a PDF for the given Tour
        /// </summary>
        /// <param name="id">Id of the tour to create pdf</param>
        /// <returns>byte[] or null if route not found</returns>
        public Task<byte[]> GeneratePDF(int id);

        /// <summary>
        /// Generates a statistic pdf over all tours/logs
        /// </summary>
        /// <returns>byte[] or null if no routes exists</returns>
        public Task<byte[]> GenerateStatistic();
        
        #region Route
        /// <summary>
        /// Creates a Route
        /// </summary>
        /// <param name="entity">RouteEntity to create</param>
        /// <returns>Id of the created route or smaller 1 if there was an problem</returns>
        public Task<int> CreateRoute(RouteEntity entity);
        /// <summary>
        /// Updates an existing route
        /// </summary>
        /// <param name="entity">Route to update</param>
        /// <returns>the updated route or null if there was an error</returns>
        public Task<RouteEntity> UpdateRoute(RouteEntity entity);

        /// <summary>
        /// Deletes an route
        /// </summary>
        /// <param name="id">route to delete</param>
        /// <returns>true on success else false</returns>
        public Task<bool> DeleteRoute(int id);
        /// <summary>
        /// Retrieving all Routes
        /// </summary>
        /// <returns>List of RouteEntity, can be empty list if no Routes found</returns>
        public Task<List<RouteEntity>> GetAllRoutes();
        /// <summary>
        /// Retrieve a specific Route
        /// </summary>
        /// <param name="id">route to retrieve</param>
        /// <returns>RouteEntity or null if not found</returns>
        public Task<RouteEntity> GetRoute(int id);

        #endregion
        
        #region Log
        /// <summary>
        /// Creates an Log Entry
        /// </summary>
        /// <param name="entity">Entity to create</param>
        /// <returns>id of the created entry or smaller 1 on error</returns>
        public Task<int> CreateLog(LogEntity entity);
        /// <summary>
        /// Updates an Log Entry
        /// </summary>
        /// <param name="entity">Entry to update</param>
        /// <returns>Updated Entry or null on error</returns>
        public Task<LogEntity> UpdateLog(LogEntity entity);

        /// <summary>
        /// Retrieve all Logs for a specific route
        /// </summary>
        /// <param name="routeId">Logs to retrieve from a specific route</param>
        /// <returns>LogEntity List, can be empty if no log found</returns>
        public Task<List<LogEntity>> GetAllLogsForId(int routeId);
        /// <summary>
        /// Deletes a specific log entry
        /// </summary>
        /// <param name="id">entry to delete</param>
        /// <returns>true on success else false</returns>
        public Task<bool> DeleteLog(int id);
        #endregion
    }
}