using System.Threading.Tasks;
using TourService.Entities;

namespace frontend.API
{
    public interface IRouteService
    {
        public Task<byte[]> GetRouteImage(string origin, string destination);
        public Task<byte[]> GeneratePDF(RouteEntity entity);
    }
}