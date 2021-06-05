using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using frontend.API;
using frontend.CustomControls;
using frontend.Entities;
using frontend.Extensions;
using frontend.Model;
using frontend.Navigation;
using frontend.ViewModels;
using Serilog;

namespace frontend.Commands.Route
{
    public class SwitchToCreateLogCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        private readonly IUserInteractionService _interaction;
        private readonly ILogger _logger = Log.ForContext<SwitchToCreateLogCommand>();
        
        public SwitchToCreateLogCommand(INavigator navigator, IUserInteractionService interaction)
        {
            _navigator = navigator;
            _interaction = interaction;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var model = new LogModel() {Route_id = (int)parameter};
                _navigator.ChangeViewModel(ViewType.CreateLog);
                Messenger.Default.Send<LogModel>(model,nameof(UpSertLogViewModel));
            }
            catch (Exception e)
            {
                _interaction.ShowErrorMessageBox(Languages.Strings.error_unexpected);
                _logger.Error($"Unexpected Error: \n {e.Message}");
            }
        }
    }
}