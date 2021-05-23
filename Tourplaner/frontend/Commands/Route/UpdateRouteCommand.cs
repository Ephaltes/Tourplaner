using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using frontend.API;
using frontend.CustomControls;
using frontend.Entities;
using frontend.Extensions;
using frontend.Model;
using frontend.Navigation;
using frontend.ViewModels;
using Serilog;

namespace frontend.Commands.Route
{
    public class UpdateRouteCommand : AsyncCommandBase
    {
        private readonly ITourService _service;
        private readonly INavigator _navigator;
        private RouteModel _routeModel;
        private readonly IUserInteractionService _interaction;
        private readonly ILogger _logger = Log.ForContext<UpdateRouteCommand>();
        
        public UpdateRouteCommand(ITourService service, INavigator navigator, RouteModel routeModel, IUserInteractionService interaction)
        {
            _service = service;
            _navigator = navigator;
            _routeModel = routeModel;
            _interaction = interaction;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            var response = await _service.UpdateRoute(_routeModel.ToEntity());

            if (response != null)
            {
                _navigator.ChangeViewModel(ViewType.Home);
                return;
            }
            _interaction.ShowErrorMessageBox("Error updating Route");
            _logger.Error("Updating Route error");
        }
    }
}