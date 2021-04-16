using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.Commands.Settings;
using frontend.Navigation;
using frontend.Languages;
using Serilog;

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
                Log.Debug("CurrentLanguage Set");
                if (_currentLanguage == value) return;
                _currentLanguage = value;
                OnPropertyChanged(nameof(CurrentLanguage));
            }
        }

        public ICommand ChangeLanguage { get; set; }

        public SettingsViewModel()
        {
            Log.Debug("CTOR SettinvsViewModel");
            ChangeLanguage = new ChangeLanguageCommand();
            Languages = new ObservableCollection<ComboBoxItem>();
            Languages.Add(new ComboBoxItem() { Content = Strings.English, Tag = "en-US" });
            Languages.Add(new ComboBoxItem() { Content = Strings.German, Tag = "de-DE" });

            foreach(var item in Languages)
            {
                if(item.Tag.ToString() == Properties.Settings.Default.language)
                {
                    CurrentLanguage = item;
                }
            }
        }
    }
}