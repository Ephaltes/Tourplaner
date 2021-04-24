using System.Threading.Tasks;
using frontend.Entities;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class SaveRouteCommand : AsyncCommandBase
    {
        private RouteEntity _routeEntity;
        
        public SaveRouteCommand(RouteEntity routeEntity)
        {
            _routeEntity = routeEntity;
        }
        public override Task ExecuteAsync(object parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}