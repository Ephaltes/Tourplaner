using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using frontend.Annotations;
using frontend.ViewModels;

namespace frontend.Commands
{
    public class IncreaseCountCommand : AsyncCommandBase
    {

        private readonly DefaultViewModel _defaultViewModel;

        public IncreaseCountCommand(DefaultViewModel defaultViewModel)
        {
            _defaultViewModel = defaultViewModel;

            _defaultViewModel.PropertyChanged += (sender, args) =>
            {
                Debug.Print("command: reveived prop changed");
                if (args.PropertyName == "Input")
                {
                    Debug.Print("command: reveived prop changed of Input");
                }
            };

        }

        public override Task ExecuteAsync(object parameter)
        {
            _defaultViewModel.CountValue = (Convert.ToInt32(_defaultViewModel.CountValue) + _defaultViewModel.CountIncreaseValue).ToString();
            return Task.CompletedTask;
        }
    }
}