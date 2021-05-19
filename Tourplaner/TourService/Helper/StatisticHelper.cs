using System;
using System.Threading.Tasks;
using TourService.Entities;
using TourService.Repository;

namespace TourService.Helper
{
    public class StatisticHelper
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ILogRepository _logRepository;
        
        public StatisticHelper(ILogRepository logRepository, IRouteRepository routeRepository)
        {
            _logRepository = logRepository;
            _routeRepository = routeRepository;
        }

        public async Task<StatisticEntity> GetStatistic()
        {
            var ret = new StatisticEntity();

            var logList = await _logRepository.GetAll();
            var routeList = await _routeRepository.GetAll();

            if (routeList.Count < 1 || logList.Count < 1)
                return null;

            ret.Count = logList.Count;

            foreach (var route in routeList)
            {
                ret.TotalEstimatedDistance += route.EstimatedDistance;
            }

            foreach (var log in logList)
            {
                TimeSpan duration = (log.EndDate.Date + log.EndTime) - (log.StartDate.Date + log.StartTime);
                ret.TotalDistance += log.Distance;
                ret.TotalTime += duration;
                ret.AverageSpeed += log.Distance / duration.TotalHours;
            }

            ret.AverageSpeed /= ret.Count;

            return ret;
        }
        
    }
}