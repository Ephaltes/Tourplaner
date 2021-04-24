using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace frontend.Commands.Button_Menu
{
    public class CloseApplicationCommand : AsyncCommandBase
    {


        public CloseApplicationCommand()
        {
        }

        public override Task ExecuteAsync(object parameter)
        {
            Log.Debug("CloseApplication Command");
            
            if (parameter is Window window)
            {
                window.Close();
            }
            return Task.CompletedTask;
        }
    }
}