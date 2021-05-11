using System;
using System.Threading.Tasks;
using frontend.Navigation;
using frontend.ViewModels.Factories;
using Serilog;

namespace frontend.Commands.Navigation
{
    public class UpdateCurrentViewModelCommand : AsyncCommandBase
    {

        private readonly ILogger _logger = Log.ForContext<UpdateCurrentViewModelCommand>();
        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public override Task ExecuteAsync(object parameter)
        {
            _logger.Debug("UpdateCurrentviewModel Command");
            ViewType viewType = (ViewType)Enum.Parse(typeof(ViewType), parameter.ToString() ?? throw new InvalidOperationException());

            if (Enum.IsDefined(typeof(ViewType),viewType))
            {
                _navigator.ChangeViewModel(viewType);
            }
            return Task.CompletedTask;
        }

    }
}