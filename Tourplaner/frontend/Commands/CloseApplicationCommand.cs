using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using frontend.Annotations;
using frontend.ViewModels;

namespace frontend.Commands
{
    public class CloseApplicationCommand : AsyncCommandBase
    {

        private readonly MainWindowViewModel _viewModel;

        public CloseApplicationCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override Task ExecuteAsync(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
            return Task.CompletedTask;
        }
    }
}