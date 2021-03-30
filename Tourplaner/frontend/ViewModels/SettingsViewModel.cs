using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.Navigation;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        public ObservableCollection<ComboBoxItem> Languages { get; set; }

        private ComboBoxItem _currentLanguage;
        public ComboBoxItem CurrentLanguage
        {
            get { return _currentLanguage; }
            set
            {
                if (_currentLanguage == value) return;
                _currentLanguage = value;
                OnPropertyChanged(nameof(CurrentLanguage));
            }
        }
        public SettingsViewModel()
        {
            Languages = new ObservableCollection<ComboBoxItem>();
            Languages.Add(new ComboBoxItem() { Content = "English", Tag = "en-US" });
            Languages.Add(new ComboBoxItem() { Content = "German", Tag = "de-DE" });
            CurrentLanguage = Languages[0];
        }
    }
}