using System.Windows.Input;
using frontend.Commands;

namespace frontend.ViewModels
{
    public class ButtonMenuViewModel : ViewModelBase
    {
        private string _resizeIconPath;
        public ICommand CloseApplication { get; }
        public ICommand MinimizeApplication { get; }
        public ICommand ResizeApplication { get; }

        public string ResizeIconPath 
        {
            get => _resizeIconPath;
            set
            {
                _resizeIconPath = value;
                OnPropertyChanged(nameof(ResizeIconPath));
            }
        }

        public ButtonMenuViewModel()
        {
            ResizeIconPath = Constants.MaximizePath;
            CloseApplication = new CloseApplicationCommand(this);
            MinimizeApplication = new MinimizeApplicationCommand(this);
            ResizeApplication = new ResizeApplicationCommand(this);
        }
    }
}