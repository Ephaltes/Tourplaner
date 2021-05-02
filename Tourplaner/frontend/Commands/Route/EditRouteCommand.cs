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
        private readonly EditRouteviewModel _editRouteviewModel;
        public EditRouteCommand(INavigator navigator, EditRouteviewModel editRouteviewModel)
        {
            _navigator = navigator;
            _editRouteviewModel = editRouteviewModel;
        }

        public override Task ExecuteAsync(object parameter)
        {
            _editRouteviewModel.SetRouteModel((RouteModel)parameter);
            _navigator.ChangeViewModel(ViewType.EditRoute);
            return Task.CompletedTask;
        }
    }
}