using System;
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
    public class CreateLogCommand : AsyncCommandBase
    {
        private LogModel _logModel;
        private INavigator _navigator;
        private readonly ITourService _tourService;
        private readonly IUserInteractionService _interaction;
        private readonly ILogger _logger = Log.ForContext<CreateLogCommand>();
        
        public CreateLogCommand(LogModel logModel, INavigator navigator, ITourService tourService, IUserInteractionService interaction)
        {
            _logModel = logModel;
            _navigator = navigator;
            _tourService = tourService;
            _interaction = interaction;
        }
        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                int response = await _tourService.CreateLog(_logModel.ToEntity());
                if (response > 0)
                {
                    _navigator.ChangeViewModel(ViewType.Home);
                    return;
                }
            
                _interaction.ShowErrorMessageBox(Languages.Strings.error_create_log);
                _logger.Error("Creating Log error");
            }
            catch (Exception e)
            {
                _interaction.ShowErrorMessageBox(Languages.Strings.error_unexpected);
                _logger.Error($"Unexpected Error\n {e.Message}");
            }
        }
    }
}