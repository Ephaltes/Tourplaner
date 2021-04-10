using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using frontend.Annotations;
using frontend.ViewModels;
using Serilog;

namespace frontend.Commands
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