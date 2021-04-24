using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
    public class EditRouteviewModel : ViewModelBase
    {

        private RouteEntity _routeEntity;
        private IRouteService _routeService;
        
        [Required (ErrorMessage = "Name for Route is required")]
        [Display(Name = "Name")]
        public string Name
        {
            get => _routeEntity.Name;
            set
            {
                Log.Debug("Name Set");
                if (Name == value) return;
                _routeEntity.Name = value;
                OnPropertyChanged();
            }
        }

        [Required (ErrorMessage = "Origin for Route is required")]
        [Display(Name = "Origin")]
        public string Origin
        {
            get => _routeEntity.Origin;
            set
            {
                Log.Debug("Origin Set");
                if (Origin == value) return;
                _routeEntity.Origin = value;
                if (!String.IsNullOrWhiteSpace(Origin) &&
                    !String.IsNullOrWhiteSpace(Destination))
                    ImageSource = _routeService.GetRouteImage(Origin, Destination);
                OnPropertyChanged();
            }
        }

        private string _destination;

        [Required (ErrorMessage = "Destination for Route is required")]
        [Display(Name = "Destination")]
        public string Destination
        {
            get => _routeEntity.Destination;
            set
            {
                Log.Debug("Destination Set");
                if (Destination == value) return;
                _routeEntity.Destination = value;
                if (!String.IsNullOrWhiteSpace(Origin) &&
                    !String.IsNullOrWhiteSpace(Destination))
                    ImageSource = _routeService.GetRouteImage(Origin, Destination);
                OnPropertyChanged();
            }
        }

        private string _description;

        [Required (ErrorMessage = "Description for Route is required")]
        [Display(Name = "Description")]
        public string Description
        {
            get => _routeEntity.Description; 
            set
            {
                Log.Debug("Description Set");
                if (Description == value) return;
                _routeEntity.Description = value;
                OnPropertyChanged();
            }
        }

        private string _imageSource;

        [Required (ErrorMessage = "Could not find Route for Origin & Destination")]
        [Display(Name = "ImageSource")]
        public string ImageSource
        {
            get => _routeEntity.ImageSource;
            set
            {
                Log.Debug("ImageSource Set");
                if (ImageSource == value) return;
                _routeEntity.ImageSource = value;
                OnPropertyChanged();
            }
        }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public ICommand SaveRouteCommand { get; set; }
        
        public EditRouteviewModel(INavigator navigator, IRouteService routeService, HomeViewModel homeViewModel)
        {
            _routeService = routeService;
            _routeEntity = homeViewModel.SelectedRoute;
            
            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(navigator);

            SaveRouteCommand = new SaveRouteCommand(_routeEntity);
        }
    }
}