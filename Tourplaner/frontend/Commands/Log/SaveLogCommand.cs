using System.Threading.Tasks;
using frontend.Entities;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class SaveLogCommand : AsyncCommandBase
    {
        private LogEntity _logEntity;
        private HomeViewModel _homeViewModel;
        
        public SaveLogCommand(LogEntity logEntity, HomeViewModel homeViewModel)
        {
            _logEntity = logEntity;
            _homeViewModel = homeViewModel;
        }
        public override Task ExecuteAsync(object parameter)
        {
            _homeViewModel.SelectedRoute.Logs.Value.Add(_logEntity);
            return Task.CompletedTask;
            
        }
    }
}