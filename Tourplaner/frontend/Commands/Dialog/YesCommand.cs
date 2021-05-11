using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace frontend.Commands.Dialog
{
    public class YesCommand : AsyncCommandBase
    {

        private readonly ILogger _logger = Log.ForContext<YesCommand>();
        public YesCommand()
        {
        }

        public override Task ExecuteAsync(object parameter)
        {
            _logger.Debug("Yes Command");

            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
            return Task.CompletedTask;
        }
    }
}
