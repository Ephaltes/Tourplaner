using System;
using System.Threading.Tasks;
using System.Windows.Input;
using frontend.Navigation;
using frontend.ViewModels.Factories;

namespace frontend.Commands
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
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _tourplanerViewModelAbstractFactory.CreateViewModel(viewType);
            }
            return Task.CompletedTask;
        }

    }
}