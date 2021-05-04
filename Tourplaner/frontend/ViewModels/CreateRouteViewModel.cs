using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class CreateRouteViewModel : ViewModelBase, INotifyDataErrorInfo
    {

        private RouteModel _routeModel;
        private ITourService _tourService;
        
        [Required (ErrorMessage = "Name for Route is required")]
        [Display(Name = "Name")]
        public string Name
        {
            get => _routeModel.Name;
            set
            {
                Log.Debug("Name Set");
                if (Name == value) return;
                _routeModel.Name = value;
                _errorViewModel.Validate(value,this, nameof(Name));
                OnPropertyChanged();
            }
        }

        [Required (ErrorMessage = "Origin for Route is required")]
        [Display(Name = "Origin")]
        public string Origin
        {
            get => _routeModel.Origin;
            set
            {
                Log.Debug("Origin Set");
                if (Origin == value) return;
                _routeModel.Origin = value;
                if (!String.IsNullOrWhiteSpace(Origin) &&
                    !String.IsNullOrWhiteSpace(Destination))
                    GetRouteImage();
                _errorViewModel.Validate(value,this, nameof(Origin));
                OnPropertyChanged();
            }
        }

        [Required (ErrorMessage = "Destination for Route is required")]
        [Display(Name = "Destination")]
        public string Destination
        {
            get => _routeModel.Destination;
            set
            {
                Log.Debug("Destination Set");
                if (Destination == value) return;
                _routeModel.Destination = value;
                if (!String.IsNullOrWhiteSpace(Origin) &&
                    !String.IsNullOrWhiteSpace(Destination))
                    GetRouteImage();
                _errorViewModel.Validate(value,this, nameof(Destination));
                OnPropertyChanged();
            }
        }


        [Required (ErrorMessage = "Description for Route is required")]
        [Display(Name = "Description")]
        public string Description
        {
            get => _routeModel.Description; 
            set
            {
                Log.Debug("Description Set");
                if (Description == value) return;
                _routeModel.Description = value;
                _errorViewModel.Validate(value,this, nameof(Description));
                OnPropertyChanged();
            }
        }


        [Required (ErrorMessage = "Could not find Route for Origin & Destination")]
        [Display(Name = "ImageSource")]
        public byte[] ImageSource
        {
            get => _routeModel.ImageSource;
            set
            {
                Log.Debug("ImageSource Set");
                if (ImageSource == value) return;
                _routeModel.ImageSource = value;
                _errorViewModel.Validate(value,this, nameof(ImageSource));
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public ICommand SaveRouteCommand { get; set; }

        private readonly ErrorViewModel _errorViewModel;
        public bool CanSend => !HasErrors;
        
        public CreateRouteViewModel(INavigator navigator, ITourService tourService)
        {
            _tourService = tourService;
            _routeModel = new RouteModel(tourService);
            _errorViewModel = new ErrorViewModel();
            _errorViewModel.ErrorsChanged += ErrorViewModelOnErrorsChanged;
            
            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(navigator);

            SaveRouteCommand = new CreateRouteCommand(_tourService,navigator,_routeModel);
            
           _errorViewModel.Validate(null,this,nameof(Name));
           _errorViewModel.Validate(null,this,nameof(Description));
           _errorViewModel.Validate(null,this,nameof(Origin));
           _errorViewModel.Validate(null,this,nameof(Destination));
           _errorViewModel.Validate(null,this,nameof(ImageSource));
        }

        private void ErrorViewModelOnErrorsChanged(object? sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this,e);
            OnPropertyChanged(nameof(HasErrors));
            OnPropertyChanged(nameof(CanSend));
        }

        private async Task GetRouteImage()
        {
            ImageSource = await _tourService.GetRouteImage(Origin, Destination);
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return _errorViewModel.GetErrors(propertyName);
        }

        public bool HasErrors => _errorViewModel.HasErrors;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    }
}