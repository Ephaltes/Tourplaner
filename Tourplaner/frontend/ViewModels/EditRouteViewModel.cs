using System;
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
    public class EditRouteviewModel : ViewModelBase
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
                OnPropertyChanged();
            }
        }

        private string _destination;

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
                OnPropertyChanged();
            }
        }

        private string _description;

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
                OnPropertyChanged();
            }
        }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public ICommand SaveRouteCommand { get; set; }
        
        public EditRouteviewModel(INavigator navigator, ITourService tourService)
        {
            _navigator = navigator;
            _tourService = tourService;
            
            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(navigator);

        }

        public void SetRouteModel(RouteModel model)
        {
            _routeModel = model;
            SaveRouteCommand = new SaveRouteCommand(_tourService,_navigator,model);
        }
        
        private async Task GetRouteImage()
        {
            ImageSource = await _tourService.GetRouteImage(Origin, Destination);
        }
    }
}