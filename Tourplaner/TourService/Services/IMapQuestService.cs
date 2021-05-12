using System.Threading.Tasks;
using TourService.Entities;

namespace TourService.Services
{
    public interface IMapQuestService
    {
        public Task<MapQuestEntity> GetMapQuestResponseForRoute(string from, string to, string language);
        public Task<byte[]> GetImageSourceForRoute(MapQuestEntity entity);
    }
}