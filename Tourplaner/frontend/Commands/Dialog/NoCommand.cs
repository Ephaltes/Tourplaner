using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace frontend.Commands.Dialog
{
    public class NoCommand : AsyncCommandBase
    {

        private readonly ILogger _logger = Log.ForContext<NoCommand>();
        public NoCommand()
        {
        }

        public override Task ExecuteAsync(object parameter)
        {
            _logger.Debug("No Command");
            
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
            return Task.CompletedTask;
        }
    }
}