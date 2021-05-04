using System;
using TourService.Entities;

namespace frontend.Model
{
    public class LogModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; } = new DateTime();
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }
        public MovementMode MovementMode { get; set; }
        public double Rating { get; set; }
        public Mood Mood { get; set; }
        public int BPM { get; set; }
        public string Note { get; set; }
        public int Route_id { get; set; }
        public TimeSpan Duration => (EndDate.Date + EndTime) - (StartDate.Date + StartTime);
        public double AvgSpeed => Distance / Duration.TotalHours;

        public int Kcal
        {
            get
            {
                //https://tools.runnerspace.com/gprofile.php?do=title&title_id=802&mgroup_id=45577
                //https://captaincalculator.com/health/calorie/calories-burned-cycling-calculator/
                switch (MovementMode)
                {
                    case MovementMode.Walk:
                        return Convert.ToInt32(Constants.WalkingKcalBurnPerKm * Distance);
                    case MovementMode.Running:
                        return Convert.ToInt32(Constants.RunningKcalBurnPerKm * Distance);
                    case MovementMode.Bicycle:
                        return Convert.ToInt32(Constants.BicycleKcalBurnPerKm * Distance);
                    default:
                        return 0;
                }
            }
        }
    }
}