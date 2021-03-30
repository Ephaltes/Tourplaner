using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using frontend.Annotations;
using frontend.ViewModels;

namespace frontend.Commands
{
    public class ChangeLanguageCommand : AsyncCommandBase
    {


        public ChangeLanguageCommand()
        {

        }

        public override Task ExecuteAsync(object parameter)
        {
            if(parameter is string language && !String.IsNullOrEmpty(language))
            {
                Properties.Settings.Default.language = language;
                Properties.Settings.Default.Save();

                var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
                Process.Start(currentExecutablePath);
                Application.Current.Shutdown();
            }
            return Task.CompletedTask;
        }
    }
}