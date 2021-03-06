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

        private readonly MainWindowViewModel _mainWindowViewModel;

        public IncreaseCountCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;

            _mainWindowViewModel.PropertyChanged += (sender, args) =>
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
            _mainWindowViewModel.CountValue = (Convert.ToInt32(_mainWindowViewModel.CountValue) + _mainWindowViewModel.CountIncreaseValue).ToString();
            return Task.CompletedTask;
        }
    }
}