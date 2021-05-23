using System.Linq;
using System.Threading.Tasks;
using frontend.API;
using frontend.Entities;
using frontend.Model;
using frontend.ViewModels;
using Serilog;

namespace frontend.Commands.Route
{
    public class DeleteLogCommand : AsyncCommandBase
    {
        private HomeViewModel _homeViewModel;
        private ITourService _service;
        private readonly ILogger _logger = Log.ForContext<DeleteLogCommand>();

        public DeleteLogCommand(HomeViewModel homeViewModel, ITourService service)
        {
            _homeViewModel = homeViewModel;
            _service = service;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var model = (LogModel) parameter;
            //only do this after removed successfull from db
            if (await _service.DeleteLog(model.Id))
            {
                _homeViewModel.SelectedRoute.Logs.Value.Remove(model);
                return;
            }

            _homeViewModel.InteractionService.ShowErrorMessageBox("Error deleting log");
            _logger.Error("Deleting Log error");
        }
    }
}