using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using System.Windows;

namespace frontend.Commands
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
