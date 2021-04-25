using System.Collections.Generic;
using System.Threading.Tasks;
using TourService.Entities;

namespace TourService.Repository
{
    public interface ILogRepository
    {
        public Task<List<LogEntity>> GetAllForRoute(int id);
    }
}