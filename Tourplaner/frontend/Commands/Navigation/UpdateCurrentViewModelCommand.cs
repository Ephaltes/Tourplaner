using System;
using System.Threading.Tasks;
using frontend.Navigation;
using frontend.ViewModels.Factories;
using Serilog;

namespace frontend.Commands.Navigation
{
    public class UpdateCurrentViewModelCommand : AsyncCommandBase
    {

        private readonly ITourplanerViewModelAbstractFactory _tourplanerViewModelAbstractFactory;
        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(ITourplanerViewModelAbstractFactory tourplanerViewModelAbstractFactory, INavigator navigator)
        {
            _tourplanerViewModelAbstractFactory = tourplanerViewModelAbstractFactory;
            _navigator = navigator;
        }

        public override Task ExecuteAsync(object parameter)
        {
            Log.Debug("UpdateCurrentviewModel Command");
            ViewType viewType = (ViewType)Enum.Parse(typeof(ViewType), parameter.ToString());

            if (Enum.IsDefined(typeof(ViewType),viewType))
            {
                _navigator.CurrentViewModel = _tourplanerViewModelAbstractFactory.CreateViewModel(viewType);
            }
            return Task.CompletedTask;
        }

    }
}