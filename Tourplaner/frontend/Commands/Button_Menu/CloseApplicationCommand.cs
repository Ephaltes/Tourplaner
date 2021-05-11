using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace frontend.Commands.Button_Menu
{
    public class CloseApplicationCommand : AsyncCommandBase
    {
        private readonly ILogger _logger = Log.ForContext<CloseApplicationCommand>();

        public CloseApplicationCommand()
        {
        }

        public override Task ExecuteAsync(object parameter)
        {
            _logger.Debug("CloseApplication Command");
            
            if (parameter is Window window)
            {
                window.Close();
            }
            return Task.CompletedTask;
        }
    }
}