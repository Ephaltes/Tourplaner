using System;

namespace TourService.Entities
{
    public class StatisticEntity
    {
        public int Count { get; set; }
        public TimeSpan TotalTime { get; set; }
        public double TotalDistance { get; set; }
        public double AverageSpeed { get; set; }
        public double TotalEstimatedDistance { get; set; }
    }
}