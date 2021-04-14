using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace frontend.Commands.Button_Menu
{
    public class MinimizeApplicationCommand : AsyncCommandBase
    {


        public MinimizeApplicationCommand()
        {
        }

        public override Task ExecuteAsync(object parameter)
        {
            Log.Debug("MinimizeApplication Command");
            if (parameter is Window window)
            {
                window.WindowState = WindowState.Minimized;
            }
            return Task.CompletedTask;
        }
    }
}