using System;
using System.Collections;
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
using frontend.Model;
using frontend.ViewModels.Factories;
using Serilog;
using TourService.Entities;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class EditLogViewModel : ErrorViewModel
    {
        private readonly ILogger _logger = Log.ForContext<EditLogViewModel>();


        private LogModel _logModel;
        private INavigator _navigator;
        private ITourService _tourService;
        
        [Required (ErrorMessage = "StartDate is required")]
        [Display(Name = "StartDate")]
        public DateTime StartDate
        {
            get => _logModel.StartDate;
            set
            {
                _logger.Debug("Date Set");
                if (StartDate == value) return;
                _logModel.StartDate = (value);
                //Validate(value, nameof(StartDate));
                OnPropertyChanged();
            }
        }
        
        [Required (ErrorMessage = "EndDate is required")]
        [Display(Name = "EndDate")]
        public DateTime EndDate
        {
            get => _logModel.EndDate;
            set
            {
                _logger.Debug("Date Set");
                if (EndDate == value) return;
                _logModel.EndDate = (value);
                //Validate(value, nameof(EndDate));
                OnPropertyChanged();
            }
        }

        //https://stackoverflow.com/questions/8318236/regex-pattern-for-hhmmss-time-string
        [Required (ErrorMessage = "StartTime is required")]
        [RegularExpression(@"^(?:(?:([01]?\d|2[0-3]):)?([0-5]?\d):)?([0-5]?\d)$", ErrorMessage = "Format has to be HH:MM:SS")]
        [Display(Name = "StartTime")]
        public string StartTime
        {
            get => _logModel.StartTime.ToString(@"hh\:mm\:ss");
            set
            {
                _logger.Debug("Origin Set");
                if (StartTime == value) return;
                if (TimeSpan.TryParse(value, out var newTime))
                {
                    _logModel.StartTime = newTime;
                }
                //Validate(value, nameof(StartTime));
                OnPropertyChanged();
            }
        }


        [Required (ErrorMessage = "EndTime is required")]
        [RegularExpression(@"^(?:(?:([01]?\d|2[0-3]):)?([0-5]?\d):)?([0-5]?\d)$", ErrorMessage = "Format has to be HH:MM:SS")]
        [Display(Name = "StopTime")]
        public string EndTime
        {
            get => _logModel.EndTime.ToString(@"hh\:mm\:ss");
            set
            {
                _logger.Debug("EndTime Set");
                if (EndTime == value) return;
                if (TimeSpan.TryParse(value, out var newTime))
                {
                    _logModel.EndTime = newTime;
                }
                //Validate(value, nameof(EndTime));
                OnPropertyChanged();
            }
        }


        [Required (ErrorMessage = "Origin is required")]
        [Display(Name = "Origin")]
        public string Origin
        {
            get => _logModel.Origin; 
            set
            {
                _logger.Debug("Origin Set");
                if (Origin == value) return;
                _logModel.Origin = value;       
                //Validate(value, nameof(Origin));
                OnPropertyChanged();
         
            }
        }

        [Required (ErrorMessage = "Destination is required")]
        [Display(Name = "Destination")]
        public string Destination
        {
            get => _logModel.Destination;
            set
            {
                _logger.Debug("Destination Set");
                if (Destination == value) return;
                _logModel.Destination = value;
                //Validate(value, nameof(Destination));
                OnPropertyChanged();
            }
        }
        
        [Required (ErrorMessage = "Distance is required")]
        [Range(1,100000,ErrorMessage = "Number between 1 and 100 000")]
        [Display(Name = "Distance")]
        public double Distance
        {
            get => _logModel.Distance;
            set
            {
                _logger.Debug("ImageSource Set");
                if (Distance == value) return;
                _logModel.Distance = (value);
                //Validate(value, nameof(Distance));
                OnPropertyChanged();
            }
        }
        
        [Required (ErrorMessage = "Movement is required")]
        [Display(Name = "Movement")]
        public MovementMode SelectedMovement
        {
            get => _logModel.MovementMode;
            set
            {
                _logger.Debug("Mood Set");
                if (SelectedMovement == value) return;
                _logModel.MovementMode = value;
                OnPropertyChanged();
            }
        }
        
                
        [Required (ErrorMessage = "Rating is required")]
        [Range(0,10)]
        [Display(Name = "Rating")]
        public double Rating
        {
            get => _logModel.Rating;
            set
            {
                _logger.Debug("Rating Set");
                if (Rating == value) return;
                _logModel.Rating = Convert.ToDouble(value);
                //Validate(value, nameof(Rating));
                OnPropertyChanged();
            }
        }
        
        [Required (ErrorMessage = "Mood is required")]
        [Display(Name = "Mood")]
        public Mood SelectedMood
        {
            get => _logModel.Mood;
            set
            {
                _logger.Debug("Mood Set");
                if (SelectedMood == value) return;
                _logModel.Mood = value;
                OnPropertyChanged();
            }
        }
        
        [Required (ErrorMessage = "BPM is required")]
        [Range(30,250,ErrorMessage = "BPM between 30-250")]
        [Display(Name = "BPM")]
        public int BPM
        {
            get => _logModel.BPM;
            set
            {
                _logger.Debug("Mood Set");
                if (BPM == value) return;
                _logModel.BPM = value;
                //Validate(value, nameof(BPM));
                OnPropertyChanged();
            }
        }
        
        [Display(Name = "Note")]
        public string Note
        {
            get => _logModel.Note;
            set
            {
                _logger.Debug("Mood Set");
                if (Note == value) return;
                _logModel.Note = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MovementMode> MovementList { get; set; }
        public ObservableCollection<Mood> MoodList { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public ICommand SaveLogCommand { get; set; }
        
        public EditLogViewModel(INavigator navigator,ITourService tourService)
        {
            _navigator = navigator;
            _tourService = tourService;
            Messenger.Default.Register<LogModel>(this, SetLogModel, nameof(EditLogViewModel));
            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(navigator);
        }
        
        private void SetLogModel(LogModel model)
        {
            _logModel = model;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            
            MovementList = new ObservableCollection<MovementMode>(Enum.GetValues(typeof(MovementMode)).Cast<MovementMode>());
            SelectedMovement = MovementList.First();
            
            MoodList = new ObservableCollection<Mood>(Enum.GetValues(typeof(Mood)).Cast<Mood>());
            SelectedMood = MoodList.First();
            
            SaveLogCommand = new UpdateLogCommand(_logModel,_navigator,_tourService);
            
            // _errorViewModel.Validate(null,this,nameof(StartDate));
            // _errorViewModel.Validate(null,this,nameof(EndDate));
            // _errorViewModel.Validate(null,this,nameof(StartTime));
            // _errorViewModel.Validate(null,this,nameof(EndTime));
            // _errorViewModel.Validate(null,this,nameof(Origin));
            // _errorViewModel.Validate(null,this,nameof(Destination));
            // _errorViewModel.Validate(null,this,nameof(Distance));
            // _errorViewModel.Validate(null,this,nameof(SelectedMovement));
            // _errorViewModel.Validate(null,this,nameof(Rating));
            // _errorViewModel.Validate(null,this,nameof(SelectedMood));
            // _errorViewModel.Validate(null,this,nameof(BPM));
            // _errorViewModel.Validate(null,this,nameof(Rating));
        }
    }
}