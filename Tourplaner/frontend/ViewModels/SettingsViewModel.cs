using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.Commands.Settings;
using frontend.Entities;
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
        public ObservableCollection<Language> Languages { get; set; }

        private Language _currentLanguage;
        public Language CurrentLanguage
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
            
            Languages = new ObservableCollection<Language>();
            Languages.Add(new Language() { Description = Strings.English, LanguageId = "en-US" });
            Languages.Add(new Language() { Description = Strings.German, LanguageId = "de-DE" });

            foreach(var item in Languages)
            {
                if(item.LanguageId == Properties.Settings.Default.language)
                {
                    CurrentLanguage = item;
                }
            }
        }
    }
}