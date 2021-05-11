using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace frontend.Commands.Button_Menu
{
    public class MinimizeApplicationCommand : AsyncCommandBase
    {
        private readonly ILogger _logger = Log.ForContext<MinimizeApplicationCommand>();

        public MinimizeApplicationCommand()
        {
        }

        public override Task ExecuteAsync(object parameter)
        {
            _logger.Debug("MinimizeApplication Command");
            if (parameter is Window window)
            {
                window.WindowState = WindowState.Minimized;
            }
            return Task.CompletedTask;
        }
    }
}