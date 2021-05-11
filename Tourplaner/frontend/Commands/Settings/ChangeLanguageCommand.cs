using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using Serilog;

namespace frontend.Commands.Settings
{
    public class ChangeLanguageCommand : AsyncCommandBase
    {
        private readonly ILogger _logger = Log.ForContext<ChangeLanguageCommand>();

        public ChangeLanguageCommand()
        {

        }

        public override Task ExecuteAsync(object parameter)
        {
            _logger.Debug("ChangeLanguage Command");
            
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