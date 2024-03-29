﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;
using frontend.API;
using frontend.Commands.Navigation;
using frontend.Commands.Route;
using frontend.CustomControls;
using frontend.Model;
using frontend.Navigation;
using frontend.Validation;
using Serilog;
using TourService.Entities;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class UpSertLogViewModel : ErrorViewModel
    {

        private LogModel _logModel;
        private readonly ILogger _logger = Log.ForContext<UpSertLogViewModel>();
        private readonly INavigator _navigator;
        private readonly ITourService _tourService;
        private IUserInteractionService _interaction;

        
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
        [DateEqualOrBiggerThan("StartDate")]
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
                //Validate(value,nameof(EndTime));
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
                _logModel.Distance = value;
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
                _logModel.Rating = value;
                //Validate(Convert.ToDouble(value), nameof(Rating));
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
                //Validate(value, nameof(Note));
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MovementMode> MovementList { get; set; }
        public ObservableCollection<Mood> MoodList { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public ICommand SaveLogCommand { get; set; }
        
        public UpSertLogViewModel(INavigator navigator,ITourService tourService, IUserInteractionService interaction)
        {
            _navigator = navigator;
            _tourService = tourService;
            _interaction = interaction;
            Messenger.Default.Register<LogModel>(this, SetLogModel, nameof(UpSertLogViewModel));
            
            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(navigator);
        }

        private void SetLogModel(LogModel model)
        {
            _logModel = model;
            
            StartDate = _logModel.Id == 0 ? DateTime.Today : _logModel.StartDate;
            EndDate = _logModel.Id == 0 ? DateTime.Today.AddDays(1) : _logModel.EndDate;
            StartTime = _logModel.Id == 0 ? DateTime.Now.TimeOfDay.ToString() : _logModel.StartTime.ToString();  
            EndTime = _logModel.Id == 0 ? DateTime.Now.AddHours(1).TimeOfDay.ToString() : _logModel.EndTime.ToString();
            
            MovementList = new ObservableCollection<MovementMode>(Enum.GetValues(typeof(MovementMode)).Cast<MovementMode>());
            SelectedMovement = _logModel.Id == 0 ?MovementList.First() : _logModel.MovementMode;
            
            MoodList = new ObservableCollection<Mood>(Enum.GetValues(typeof(Mood)).Cast<Mood>());
            SelectedMood = _logModel.Id == 0 ? MoodList.First() : _logModel.Mood;

            if (model.Id == 0)
                SaveLogCommand = new CreateLogCommand(_logModel, _navigator, _tourService, _interaction);
            else
                SaveLogCommand = new UpdateLogCommand(_logModel, _navigator, _tourService, _interaction);
            
            Validate(nameof(Origin));
            Validate(nameof(Destination));
            Validate(nameof(Distance));
            Validate(nameof(Rating));
            Validate(nameof(BPM));
        }
    }
}