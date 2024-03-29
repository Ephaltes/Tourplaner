﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using frontend.Commands.Settings;
using frontend.Entities;
using frontend.Languages;
using frontend.Properties;
using Serilog;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ILogger _logger = Log.ForContext<SettingsViewModel>();

        public ObservableCollection<Language> Languages { get; set; }

        private Language _currentLanguage;
        public Language CurrentLanguage
        {
            get { return _currentLanguage; }
            set
            {
                _logger.Debug("CurrentLanguage Set");
                if (_currentLanguage == value) return;
                _currentLanguage = value;
                OnPropertyChanged(nameof(CurrentLanguage));
            }
        }

        public ICommand ChangeLanguage { get; set; }

        public SettingsViewModel()
        {
            _logger.Debug("CTOR SettinvsViewModel");
            ChangeLanguage = new ChangeLanguageCommand();
            
            Languages = new ObservableCollection<Language>();
            Languages.Add(new Language() { Description = Strings.English, LanguageId = "en_US" });
            Languages.Add(new Language() { Description = Strings.German, LanguageId = "de_DE" });

            foreach(var item in Languages)
            {
                if(item.LanguageId == Settings.Default.language)
                {
                    CurrentLanguage = item;
                }
            }
        }
    }
}