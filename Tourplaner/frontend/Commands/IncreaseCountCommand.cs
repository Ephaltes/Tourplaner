using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using frontend.Annotations;
using frontend.ViewModels;
using frontend.CustomControls.Dialog;


namespace frontend.Commands
{
    public class IncreaseCountCommand : AsyncCommandBase
    {
        public IncreaseCountCommand()
        {
        }

        public override Task ExecuteAsync(object parameter)
        {
            return Task.CompletedTask;
        }
    }
}