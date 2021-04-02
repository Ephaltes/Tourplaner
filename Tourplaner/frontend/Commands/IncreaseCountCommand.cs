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
        }

        public override Task ExecuteAsync(object parameter)
        {
            return Task.CompletedTask;
        }
    }
}