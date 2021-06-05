using System.Threading.Tasks;
using System.Windows;
using frontend.ViewModels;
using Serilog;

namespace frontend.Commands.Button_Menu
{
    public class ResizeApplicationCommand : AsyncCommandBase
    {
        private readonly MainWindowViewModel _viewModel;
        private readonly ILogger _logger = Log.ForContext<ResizeApplicationCommand>();

        public ResizeApplicationCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override Task ExecuteAsync(object parameter)
        {
            _logger.Debug("ResizeApplication Command");
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