using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
    public class EditRouteViewModel : ErrorViewModel
    {

        private RouteModel _routeModel;
        private ITourService _tourService;
        private INavigator _navigator;

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
                Validate(value, nameof(Name));
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
                Validate(value, nameof(Origin));
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
                Validate(value, nameof(Destination));
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
                Validate(value, nameof(Description));
                OnPropertyChanged();
            }
        }

        private string _imageSource;

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
                Validate(value, nameof(ImageSource));
                OnPropertyChanged();
            }
        }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public ICommand SaveRouteCommand { get; set; }
        
        public EditRouteViewModel(INavigator navigator, ITourService tourService)
        {
            _navigator = navigator;
            _tourService = tourService;
            
            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(navigator);
            
            Messenger.Default.Register<RouteModel>(this,SetRouteModel,nameof(EditRouteViewModel));
        }
        
        private void SetRouteModel(RouteModel model)
        {
            _routeModel = model;
            SaveRouteCommand = new UpdateRouteCommand(_tourService,_navigator,model);
            
            // _errorViewModel.Validate(null,this,nameof(Name));
            // _errorViewModel.Validate(null,this,nameof(Description));
            // _errorViewModel.Validate(null,this,nameof(Origin));
            // _errorViewModel.Validate(null,this,nameof(Destination));
            // _errorViewModel.Validate(null,this,nameof(ImageSource));
        }
        
        private async Task GetRouteImage()
        {
            ImageSource = await _tourService.GetRouteImage(Origin, Destination);
        }
    }
}