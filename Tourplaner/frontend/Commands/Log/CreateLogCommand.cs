using System.Threading.Tasks;
using frontend.API;
using frontend.Entities;
using frontend.Extensions;
using frontend.Model;
using frontend.Navigation;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class CreateLogCommand : AsyncCommandBase
    {
        private LogModel _logModel;
        private INavigator _navigator;
        private readonly ITourService _tourService;
        
        public CreateLogCommand(LogModel logModel, INavigator navigator, ITourService tourService)
        {
            _logModel = logModel;
            _navigator = navigator;
            _tourService = tourService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            int response = await _tourService.CreateLog(_logModel.ToEntity());
            _navigator.ChangeViewModel(ViewType.Home);
        }
    }
}