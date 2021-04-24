using System.Threading.Tasks;
using frontend.Entities;
using frontend.Model;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class SaveLogCommand : AsyncCommandBase
    {
        private LogModel _logModel;
        private HomeViewModel _homeViewModel;
        
        public SaveLogCommand(LogModel logModel, HomeViewModel homeViewModel)
        {
            _logModel = logModel;
            _homeViewModel = homeViewModel;
        }
        public override Task ExecuteAsync(object parameter)
        {
            _homeViewModel.SelectedRoute.Logs.Value.Add(_logModel);
            return Task.CompletedTask;
            
        }
    }
}