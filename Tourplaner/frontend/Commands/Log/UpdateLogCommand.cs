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
    public class UpdateLogCommand : AsyncCommandBase
    {
        private LogModel _logModel;
        private INavigator _navigator;
        private readonly ITourService _tourService;
        private readonly IUserInteractionService _interaction;
        private readonly ILogger _logger = Log.ForContext<UpdateLogCommand>();
        
        public UpdateLogCommand(LogModel logModel, INavigator navigator, ITourService tourService, IUserInteractionService interaction)
        {
            _logModel = logModel;
            _navigator = navigator;
            _tourService = tourService;
            _interaction = interaction;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            var response = await _tourService.UpdateLog(_logModel.ToEntity());
            if (response != null)
            {
                _navigator.ChangeViewModel(ViewType.Home);
                return;
            }
            _interaction.ShowErrorMessageBox("Error Updating Log");
            _logger.Error("Updating Log error");
        }
    }
}