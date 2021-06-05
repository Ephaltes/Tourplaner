using System.Threading.Tasks;
using TourService.Entities;

namespace TourService.Services
{
    /// <summary>
    /// Service to interact with MapQuest Api
    /// </summary>
    public interface IMapQuestService
    {
        /// <summary>
        /// Gets Data for a route from Mapquest
        /// </summary>
        /// <param name="from">Origin</param>
        /// <param name="to">Destination</param>
        /// <param name="language">language e.g. for directions en_us, de_de</param>
        /// <returns>MapquestEntity or null if fails</returns>
        public Task<MapQuestEntity> GetMapQuestResponseForRoute(string from, string to, string language);
        /// <summary>
        /// Gets the Route image from an MapQuestEntity
        /// </summary>
        /// <param name="entity">Route to create route image from</param>
        /// <returns>data of image or null if no image could be created</returns>
        public Task<byte[]> GetImageSourceForRoute(MapQuestEntity entity);
    }
}