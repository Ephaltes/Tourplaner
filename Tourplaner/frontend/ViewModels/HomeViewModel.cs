using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using frontend.API;
using frontend.Commands.Navigation;
using frontend.Commands.Route;
using frontend.CustomControls;
using frontend.Extensions;
using frontend.Languages;
using frontend.Model;
using frontend.Navigation;
using Serilog;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class HomeViewModel : ViewModelBase
    {
        internal ObservableCollection<RouteModel> Routes { get; set; }
        private readonly ILogger _logger = Log.ForContext<HomeViewModel>();

        private RouteModel _selectedRoute;
        private string _searchText;
        private readonly ITourService _tourService;
        private CollectionViewSource CvsRoute { get; set; }
        
        public ICollectionView RoutesView => CvsRoute.View;
        public readonly IUserInteractionService InteractionService;

        public RouteModel SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                _logger.Debug("_selectedRoute Set");
                if (value != null)
                    _selectedRoute = value;
                OnPropertyChanged(nameof(SelectedRoute));
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _logger.Debug("Set searchtext");
                if (value == SearchText) return;
                _searchText = value;
                OnFilterChanged();
            }
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }
        public ICommand DeleteRouteCommand { get; set; }
        public ICommand EditRouteCommand { get; set; }
        public ICommand GeneratePDFCommand { get; set; }        
        
        public ICommand CreateLogCommand { get; set; }
        
        public ICommand EditLogCommand { get; set; }
        public ICommand DeleteLogCommand { get; set; }
        
        public ICommand ExportRouteCommand { get; set; }
        
        public ICommand ImportRouteCommand { get; set; }
        
        public ICommand GenerateStatisticCommand { get; set; }
      
        public HomeViewModel(INavigator navigator,ITourService tourService, IUserInteractionService interactionService)
        {
            _logger.Debug("CTOR HomeViewModel");
            _tourService = tourService;
            InteractionService = interactionService;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator);
            DeleteRouteCommand = new DeleteRouteCommand(this,tourService);
            EditRouteCommand = new EditRouteCommand(navigator,InteractionService);
            GeneratePDFCommand = new GeneratePDFCommand(tourService, this);
            CreateLogCommand = new SwitchToCreateLogCommand(navigator,InteractionService);
            EditLogCommand = new EditLogCommand(navigator,InteractionService);
            DeleteLogCommand = new DeleteLogCommand(this, tourService);
            ExportRouteCommand = new ExportRouteCommand(this);
            ImportRouteCommand = new ImportRouteCommand(this, tourService, navigator);
            GenerateStatisticCommand = new GenerateStatisticCommand(_tourService, this);

            IEnumerable<RouteModel> routesModel = new List<RouteModel>();
            try
            {
                routesModel = tourService.GetAllRoutes().Result.ToModel(tourService).OrderByDescending(a => a.Id);
            }
            catch (Exception e)
            {
                InteractionService.ShowErrorMessageBox(Strings.error_api_down);
            }
            Routes = new ObservableCollection<RouteModel>(routesModel);
            SelectedRoute = Routes.FirstOrDefault();

            //var test = SelectedRoute.Logs.Value;
           
            CvsRoute = new CollectionViewSource();
            CvsRoute.Source = Routes;
            CvsRoute.Filter += CvsRouteOnFilter;
        }

        //https://stackoverflow.com/questions/12188623/implementing-a-listview-filter-with-josh-smiths-wpf-mvvm-demo-app
        private void CvsRouteOnFilter(object sender, FilterEventArgs e)
        {
           _logger.Debug("Filter");
           RouteModel model = (RouteModel)e.Item;

           if (string.IsNullOrWhiteSpace(SearchText))
           {
               e.Accepted = true;
               return;
           }
           e.Accepted = model.Contains(SearchText);
        }

        private void OnFilterChanged()
        {
          CvsRoute.View.Refresh();
        }
    }
}