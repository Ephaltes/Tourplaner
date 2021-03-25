using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using frontend.Annotations;
using frontend.ViewModels;

namespace frontend.Commands
{
    public class ResizeApplicationCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _viewModel;

        public ResizeApplicationCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override Task ExecuteAsync(object parameter)
        {
            if (parameter is Window window)
            {
                if (window.WindowState == WindowState.Normal)
                {
                    window.WindowState = WindowState.Maximized;
                    _viewModel.ResizeIconPath = Constants.ResizeDown;
                    return Task.CompletedTask;
                }

                window.WindowState = WindowState.Normal;
                _viewModel.ResizeIconPath = Constants.MaximizePath;
            }
            return Task.CompletedTask;
        }
    }
}