using System;
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
    public class CreateRouteCommand : AsyncCommandBase
    {
        private readonly ITourService _service;
        private readonly INavigator _navigator;
        private RouteModel _routeModel;
        private readonly IUserInteractionService _interaction;
        private readonly ILogger _logger = Log.ForContext<CreateRouteCommand>();
        
        public CreateRouteCommand(ITourService service, INavigator navigator, RouteModel routeModel, IUserInteractionService interaction)
        {
            _service = service;
            _navigator = navigator;
            _routeModel = routeModel;
            _interaction = interaction;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                int response = await _service.CreateRoute(_routeModel.ToEntity());

                if (response > 0)
                {
                    _navigator.ChangeViewModel(ViewType.Home);
                    return;
                }
                _interaction.ShowErrorMessageBox(Languages.Strings.error_create_route);
                _logger.Error("Creating Route error");
            }
            catch (Exception e)
            {
                _interaction.ShowErrorMessageBox(Languages.Strings.error_unexpected);
                _logger.Error($"Unexpected Error\n {e.Message}");
            }
        }
    }
}