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

        private readonly HomeViewModel _homeViewModel;

        public IncreaseCountCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;

            _homeViewModel.PropertyChanged += (sender, args) =>
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
            _homeViewModel.CountValue = (Convert.ToInt32(_homeViewModel.CountValue) + _homeViewModel.CountIncreaseValue).ToString();
            return Task.CompletedTask;
        }
    }
}