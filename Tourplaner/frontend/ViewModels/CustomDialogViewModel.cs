using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.Commands.Dialog;
using frontend.Navigation;
using Serilog;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class CustomDialogViewModel : ViewModelBase
    {
        public string Text { get; set; }
        public ICommand NoCommand { get; set; }
        public ICommand YesCommand { get; set; }

        public CustomDialogViewModel(string text)
        {
            Log.Debug("CTOR CustomDialogViewModel");
            Text = text;
            NoCommand = new NoCommand();
            YesCommand = new YesCommand();
        }
    }
}