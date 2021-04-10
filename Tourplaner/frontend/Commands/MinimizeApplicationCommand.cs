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