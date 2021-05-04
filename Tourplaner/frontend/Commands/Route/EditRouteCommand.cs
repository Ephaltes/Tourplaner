using System.Threading.Tasks;
using frontend.Entities;
using frontend.Model;
using frontend.Navigation;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class EditRouteCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        public EditRouteCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public override Task ExecuteAsync(object parameter)
        {
            _navigator.ChangeViewModel(ViewType.EditRoute);
            Messenger.Default.Send<RouteModel>((RouteModel)parameter,nameof(EditRouteViewModel));
            return Task.CompletedTask;
        }
    }
}