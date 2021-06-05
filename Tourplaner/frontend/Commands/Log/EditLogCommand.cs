using System;
using System.Threading.Tasks;
using frontend.CustomControls;
using frontend.Entities;
using frontend.Model;
using frontend.Navigation;
using frontend.ViewModels;
using Serilog;

namespace frontend.Commands.Route
{
    public class EditLogCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        private readonly IUserInteractionService _interaction;
        private readonly ILogger _logger = Log.ForContext<EditLogCommand>();

        public EditLogCommand(INavigator navigator, IUserInteractionService interaction)
        {
            _navigator = navigator;
            _interaction = interaction;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                _navigator.ChangeViewModel(ViewType.EditLog);
                Messenger.Default.Send<LogModel>((LogModel) parameter, nameof(UpSertLogViewModel));
            }
            catch (Exception e)
            {
                _interaction.ShowErrorMessageBox(Languages.Strings.error_unexpected);
                _logger.Error($"Unexpected Error: \n {e.Message}");
            }
        }
    }
}