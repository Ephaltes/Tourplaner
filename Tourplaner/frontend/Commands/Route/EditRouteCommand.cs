using System.Threading.Tasks;
using frontend.Entities;
using frontend.Navigation;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class EditRouteCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        private readonly HomeViewModel _homeViewModel;
        public EditRouteCommand(INavigator navigator, HomeViewModel homeViewModel)
        {
            _navigator = navigator;
            _homeViewModel = homeViewModel;
        }

        public override Task ExecuteAsync(object parameter)
        {
            _homeViewModel.SelectedRoute = (RouteEntity) parameter;
            _navigator.ChangeViewModel(ViewType.EditRoute);
            return Task.CompletedTask;
        }
    }
}