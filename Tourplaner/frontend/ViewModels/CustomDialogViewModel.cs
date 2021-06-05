using System.Windows.Input;
using frontend.Commands.Dialog;
using Serilog;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class CustomDialogViewModel : ViewModelBase
    {
        private readonly ILogger _logger = Log.ForContext<CustomDialogViewModel>();

        public string Text { get; set; }
        public ICommand NoCommand { get; set; }
        public ICommand YesCommand { get; set; }

        public CustomDialogViewModel(string text)
        {
            _logger.Debug("CTOR CustomDialogViewModel");
            Text = text;
            NoCommand = new NoCommand();
            YesCommand = new YesCommand();
        }
    }
}