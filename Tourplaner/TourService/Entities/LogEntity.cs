using System;

namespace TourService.Entities
{
    public enum MovementMode
    {
        Running,
        Walk,
        Bicycle,
        Drive
    }

    public enum Mood
    {
        Good,
        Neutral,
        Bad
    }

    public class LogEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }
        public double Rating { get; set; }
        public string Note { get; set; }
        public MovementMode MovementMode { get; set; }
        public Mood Mood { get; set; }
        public int BPM { get; set; }
        public int Route_id { get; set; }
        //public TimeSpan Duration { get; set; }
        //public double AvgSpeed { get; set; }
        //public int Kcal { get; set; }
    }
}