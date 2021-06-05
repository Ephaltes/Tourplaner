using System;
using System.Linq;
using System.Threading.Tasks;
using frontend.API;
using frontend.Entities;
using frontend.Model;
using frontend.ViewModels;
using Serilog;

namespace frontend.Commands.Route
{
    public class DeleteRouteCommand : AsyncCommandBase
    {
        private HomeViewModel _homeViewModel;
        private ITourService _service;
        private readonly ILogger _logger = Log.ForContext<DeleteRouteCommand>();
        public DeleteRouteCommand(HomeViewModel homeViewModel, ITourService service)
        {
            _homeViewModel = homeViewModel;
            _service = service;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var model = (RouteModel) parameter;
                //only do this after removed successfull from db
                if (await _service.DeleteRoute(model.Id))
                {
                    _homeViewModel.Routes.Remove(model);
                    _homeViewModel.SelectedRoute = _homeViewModel.Routes.FirstOrDefault();
                    return;
                }
                _homeViewModel.InteractionService.ShowErrorMessageBox("Error deleting Route");
                _logger.Error("Deleting Route error");
            }
            catch (Exception e)
            {
                _homeViewModel.InteractionService.ShowErrorMessageBox("Unexpected Error");
                _logger.Error($"Unexpected Error\n {e.Message}");
            }
        }
    }
}