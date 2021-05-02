using System.Threading.Tasks;
using frontend.Entities;
using frontend.Model;
using frontend.Navigation;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class SaveLogCommand : AsyncCommandBase
    {
        private LogModel _logModel;
        private HomeViewModel _homeViewModel;
        private INavigator _navigator;
        
        public SaveLogCommand(LogModel logModel, HomeViewModel homeViewModel, INavigator navigator)
        {
            _logModel = logModel;
            _homeViewModel = homeViewModel;
            _navigator = navigator;
        }
        public override async Task ExecuteAsync(object parameter)
        {
             _homeViewModel.SelectedRoute.Logs.Value.Add(_logModel);
            _navigator.ChangeViewModel(ViewType.Home);
        }
    }
}