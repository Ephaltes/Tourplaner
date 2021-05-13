using System.Threading.Tasks;
using frontend.Entities;
using frontend.Model;
using frontend.Navigation;
using frontend.ViewModels;

namespace frontend.Commands.Route
{
    public class EditLogCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        public EditLogCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public override Task ExecuteAsync(object parameter)
        {
            _navigator.ChangeViewModel(ViewType.CreateLog);
            Messenger.Default.Send<LogModel>((LogModel)parameter,nameof(UpSertLogViewModel));
            return Task.CompletedTask;
        }
    }
}