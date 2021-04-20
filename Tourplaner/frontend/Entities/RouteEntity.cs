using System;
using System.Collections.Generic;

namespace frontend.Entities
{
    public class RouteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        
        public List<string> Directions { get; set; }

        public Lazy<List<LogEntity>> Log
        {
            get
            {
                return null;
                //Call APi get from Id
            }
        }
    }
}