using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using frontend.Annotations;
using frontend.ViewModels;

namespace frontend.Commands
{
    public class MinimizeApplicationCommand : AsyncCommandBase
    {

        private readonly ButtonMenuViewModel _viewModel;

        public MinimizeApplicationCommand(ButtonMenuViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override Task ExecuteAsync(object parameter)
        {
            if (parameter is Window window)
            {
                window.WindowState = WindowState.Minimized;
            }
            return Task.CompletedTask;
        }
    }
}