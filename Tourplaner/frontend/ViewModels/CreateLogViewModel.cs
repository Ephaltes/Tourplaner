using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using frontend.Annotations;
using frontend.API;
using frontend.Commands;
using frontend.Commands.Navigation;
using frontend.Commands.Route;
using frontend.Entities;
using frontend.Navigation;
using frontend.Languages;
using frontend.ViewModels.Factories;
using Serilog;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class CreateLogViewModel : ViewModelBase
    {

        private LogEntity _logEntity;
        
        [Required (ErrorMessage = "StartDate is required")]
        [Display(Name = "StartDate")]
        public DateTime StartDate
        {
            get => _logEntity.StartDate;
            set
            {
                Log.Debug("Date Set");
                if (StartDate == value) return;
                _logEntity.StartDate = (value);
                OnPropertyChanged();
            }
        }
        
        [Required (ErrorMessage = "EndDate is required")]
        [Display(Name = "EndDate")]
        public DateTime EndDate
        {
            get => _logEntity.EndDate;
            set
            {
                Log.Debug("Date Set");
                if (EndDate == value) return;
                _logEntity.EndDate = (value);
                OnPropertyChanged();
            }
        }

        //https://stackoverflow.com/questions/8318236/regex-pattern-for-hhmmss-time-string
        [Required (ErrorMessage = "StartTime is required")]
        [RegularExpression(@"^(?:(?:([01]?\d|2[0-3]):)?([0-5]?\d):)?([0-5]?\d)$", ErrorMessage = "Format has to be HH:MM:SS")]
        [Display(Name = "StartTime")]
        public string StartTime
        {
            get => _logEntity.StartTime.ToString(@"hh\:mm\:ss");
            set
            {
                Log.Debug("Origin Set");
                if (StartTime == value) return;
                if (TimeSpan.TryParse(value, out var newTime))
                {
                    _logEntity.StartTime = newTime;
                }
                OnPropertyChanged();
            }
        }


        [Required (ErrorMessage = "EndTime is required")]
        [RegularExpression(@"^(?:(?:([01]?\d|2[0-3]):)?([0-5]?\d):)?([0-5]?\d)$", ErrorMessage = "Format has to be HH:MM:SS")]
        [Display(Name = "StopTime")]
        public string EndTime
        {
            get => _logEntity.EndTime.ToString(@"hh\:mm\:ss");
            set
            {
                Log.Debug("EndTime Set");
                if (EndTime == value) return;
                if (TimeSpan.TryParse(value, out var newTime))
                {
                    _logEntity.EndTime = newTime;
                }
                OnPropertyChanged();
            }
        }


        [Required (ErrorMessage = "Origin is required")]
        [Display(Name = "Origin")]
        public string Origin
        {
            get => _logEntity.Origin; 
            set
            {
                Log.Debug("Origin Set");
                if (Origin == value) return;
                _logEntity.Origin = value;
                OnPropertyChanged();
            }
        }

        [Required (ErrorMessage = "Destination is required")]
        [Display(Name = "Destination")]
        public string Destination
        {
            get => _logEntity.Destination;
            set
            {
                Log.Debug("Destination Set");
                if (Destination == value) return;
                _logEntity.Destination = value;
                OnPropertyChanged();
            }
        }
        
        [Required (ErrorMessage = "Distance is required")]
        [Range(1,100000,ErrorMessage = "Number between 1 and 100 000")]
        [Display(Name = "Distance")]
        public string Distance
        {
            get => _logEntity.Distance.ToString();
            set
            {
                Log.Debug("ImageSource Set");
                if (Distance == value) return;
                _logEntity.Distance = Convert.ToDouble(value);
                OnPropertyChanged();
            }
        }
        
        [Required (ErrorMessage = "Movement is required")]
        [Display(Name = "Movement")]
        public MovementMode SelectedMovement
        {
            get => _logEntity.MovementMode;
            set
            {
                Log.Debug("Mood Set");
                if (SelectedMovement == value) return;
                _logEntity.MovementMode = value;
                OnPropertyChanged();
            }
        }
        
                
        [Required (ErrorMessage = "Rating is required")]
        [Display(Name = "Rating")]
        public string Rating
        {
            get => _logEntity.Rating.ToString();
            set
            {
                Log.Debug("Rating Set");
                if (Rating == value) return;
                _logEntity.Rating = Convert.ToDouble(value);
                OnPropertyChanged();
            }
        }
        
        [Required (ErrorMessage = "Mood is required")]
        [Display(Name = "Mood")]
        public Mood SelectedMood
        {
            get => _logEntity.Mood;
            set
            {
                Log.Debug("Mood Set");
                if (SelectedMood == value) return;
                _logEntity.Mood = value;
                OnPropertyChanged();
            }
        }
        
        [Required (ErrorMessage = "BPM is required")]
        [Range(30,250,ErrorMessage = "BPM between 30-250")]
        [Display(Name = "BPM")]
        public int BPM
        {
            get => _logEntity.BPM;
            set
            {
                Log.Debug("Mood Set");
                if (BPM == value) return;
                _logEntity.BPM = value;
                OnPropertyChanged();
            }
        }
        
        [Display(Name = "Note")]
        public string Note
        {
            get => _logEntity.Note;
            set
            {
                Log.Debug("Mood Set");
                if (Note == value) return;
                _logEntity.Note = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MovementMode> MovementList { get; set; }
        public ObservableCollection<Mood> MoodList { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public ICommand SaveLogCommand { get; set; }
        
        public CreateLogViewModel(INavigator navigator, HomeViewModel homeviewModel)
        {
            _logEntity = new LogEntity();
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            
            MovementList = new ObservableCollection<MovementMode>(Enum.GetValues(typeof(MovementMode)).Cast<MovementMode>());
            SelectedMovement = MovementList.First();
            
            MoodList = new ObservableCollection<Mood>(Enum.GetValues(typeof(Mood)).Cast<Mood>());
            SelectedMood = MoodList.First();
            
            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(navigator);

            SaveLogCommand = new SaveLogCommand(_logEntity,homeviewModel);
        }
    }
}