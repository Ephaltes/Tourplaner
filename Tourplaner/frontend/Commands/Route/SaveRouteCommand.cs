using System.Threading.Tasks;
using frontend.Entities;
using frontend.Model;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class SaveRouteCommand : AsyncCommandBase
    {
        private RouteModel _routeModel;
        
        public SaveRouteCommand(RouteModel routeModel)
        {
            _routeModel = routeModel;
        }
        public override Task ExecuteAsync(object parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}