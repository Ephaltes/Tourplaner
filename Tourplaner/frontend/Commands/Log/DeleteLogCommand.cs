using System.Linq;
using System.Threading.Tasks;
using frontend.API;
using frontend.Entities;
using frontend.Model;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class DeleteLogCommand : AsyncCommandBase
    {
        private HomeViewModel _homeViewModel;
        private ITourService _service;
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
            }
        }
    }
}