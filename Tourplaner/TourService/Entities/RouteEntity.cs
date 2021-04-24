using System.Collections.Generic;

namespace TourService.Entities
{
    public class RouteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public byte[] ImageSource { get; set; }
        public List<string> Directions { get; set; }
        public List<LogEntity> Logs { get; set; }
    }
}