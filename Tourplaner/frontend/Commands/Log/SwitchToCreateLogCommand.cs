using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using frontend.API;
using frontend.Entities;
using frontend.Extensions;
using frontend.Model;
using frontend.Navigation;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class SwitchToCreateLogCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        
        public SwitchToCreateLogCommand(INavigator navigator)
        {
            _navigator = navigator;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            var model = new LogModel() {Route_id = (int)parameter};
            _navigator.ChangeViewModel(ViewType.CreateLog);
            Messenger.Default.Send<LogModel>(model,nameof(UpSertLogViewModel));
        }
    }
}