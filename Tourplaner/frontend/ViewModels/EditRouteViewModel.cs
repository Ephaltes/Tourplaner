using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows.Input;
using frontend.API;
using frontend.Commands.Navigation;
using frontend.Commands.Route;
using frontend.CustomControls;
using frontend.Model;
using frontend.Navigation;
using Serilog;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class EditRouteViewModel : ErrorViewModel
    {
        private readonly ILogger _logger = Log.ForContext<EditRouteViewModel>();
        private IUserInteractionService _interaction;

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
                _logger.Debug("Name Set");
                if (Name == value) return;
                _routeModel.Name = value;
                //Validate(value, nameof(Name));
                OnPropertyChanged();
            }
        }

        [Required (ErrorMessage = "Origin for Route is required")]
        //[DependencyGreatgerThan("EstimatedDistance",0,ErrorMessage = "no route found")]
        [Display(Name = "Origin")]
        public string Origin
        {
            get => _routeModel.Origin;
            set
            {
                _logger.Debug("Origin Set");
                if (Origin == value) return;
                _routeModel.Origin = value;
                EstimatedDistance = 0;
                Task.Run(GetRouteInformation);
                //Validate(value, nameof(Origin));
                OnPropertyChanged();
            }
        }
        
       
        [Required (ErrorMessage = "Destination for Route is required")]
        //[DependencyGreatgerThan("EstimatedDistance",0,ErrorMessage = "no route found")]
        [Display(Name = "Destination")]
        public string Destination
        {
            get => _routeModel.Destination;
            set
            {
                _logger.Debug("Destination Set");
                if (Destination == value) return;
                _routeModel.Destination = value;
                EstimatedDistance = 0;
                Task.Run(GetRouteInformation);
                //Validate(value, nameof(Destination));
                OnPropertyChanged();
            }
        }
        

        [Range(1,1000000,ErrorMessage = "Number between 1 and 1 000 000")]
        [Display(Name = "EstimatedDistance")]
        public double EstimatedDistance
        {
            get => _routeModel.EstimatedDistance;
            set
            {
                _logger.Debug("Origin Set");
                if (Math.Abs(EstimatedDistance - value) < 0.1) return;
                _routeModel.EstimatedDistance = value;
                //Validate(value, nameof(EstimatedDistance));
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
                _logger.Debug("Description Set");
                if (Description == value) return;
                _routeModel.Description = value;
                //Validate(value, nameof(Description));
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
                _logger.Debug("ImageSource Set");
                if (ImageSource == value) return;
                _routeModel.ImageSource = value;
                //Validate(value, nameof(ImageSource));
                OnPropertyChanged();
            }
        }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public ICommand SaveRouteCommand { get; set; }
        
        public EditRouteViewModel(INavigator navigator, ITourService tourService, IUserInteractionService interaction)
        {
            _navigator = navigator;
            _tourService = tourService;
            _interaction = interaction;

            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(navigator);
            
            Messenger.Default.Register<RouteModel>(this,SetRouteModel,nameof(EditRouteViewModel));
        }
        
        private void SetRouteModel(RouteModel model)
        {
            _routeModel = model;
            SaveRouteCommand = new UpdateRouteCommand(_tourService,_navigator,model,_interaction);
            
            // _errorViewModel.Validate(null,this,nameof(Name));
            // _errorViewModel.Validate(null,this,nameof(Description));
            // _errorViewModel.Validate(null,this,nameof(Origin));
            // _errorViewModel.Validate(null,this,nameof(Destination));
            // _errorViewModel.Validate(null,this,nameof(ImageSource));
        }
        
        private async Task GetRouteInformation()
        {
            var mapQuest =  await _tourService.GetRouteInformation(Origin, Destination);
            ImageSource = mapQuest.ImageSource;
            _routeModel.Directions = mapQuest.Directions;
            EstimatedDistance = mapQuest.EstimatedDistance;
        }
    }
}