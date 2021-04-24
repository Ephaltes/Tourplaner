using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace frontend.Commands.Dialog
{
    public class YesCommand : AsyncCommandBase
    {


        public YesCommand()
        {
        }

        public override Task ExecuteAsync(object parameter)
        {
            Log.Debug("Yes Command");

            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
            return Task.CompletedTask;
        }
    }
}
