using System.Linq;
using System.Threading.Tasks;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class DeleteRouteCommand : AsyncCommandBase
    {
        private HomeViewModel _homeViewModel;
        public DeleteRouteCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public override Task ExecuteAsync(object parameter)
        {
            //only do this after removed successfull from db
            _homeViewModel.Routes.Remove(_homeViewModel.SelectedRoute);
            return Task.CompletedTask;
        }
    }
}