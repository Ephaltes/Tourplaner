using System.IO;

namespace frontend.API
{
    public class RouteService : IRouteService
    {
        public byte[] GetRouteImage(string origin, string destination)
        {
            return File.ReadAllBytes(Directory.GetCurrentDirectory()+"/images/placeholder.png");
        }
    }
}