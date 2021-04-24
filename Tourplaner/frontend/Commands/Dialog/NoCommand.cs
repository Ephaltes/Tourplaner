using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace frontend.Commands.Dialog
{
    public class NoCommand : AsyncCommandBase
    {


        public NoCommand()
        {
        }

        public override Task ExecuteAsync(object parameter)
        {
            Log.Debug("No Command");
            
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
            return Task.CompletedTask;
        }
    }
}