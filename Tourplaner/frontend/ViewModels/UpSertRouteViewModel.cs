using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.Navigation;
using frontend.Languages;
using Serilog;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class UpSertRouteViewModel : ViewModelBase
    {
        public ObservableCollection<ComboBoxItem> Languages { get; set; }

        private ComboBoxItem _currentLanguage;
        public ComboBoxItem CurrentLanguage
        {
            get { return _currentLanguage; }
            set
            {
                Log.Debug("CurrentLanguage Set");
                if (_currentLanguage == value) return;
                _currentLanguage = value;
                OnPropertyChanged(nameof(CurrentLanguage));
            }
        }

        public ICommand UpSertRouteCommand { get; set; }

        public UpSertRouteViewModel()
        {
            
        }
    }
}