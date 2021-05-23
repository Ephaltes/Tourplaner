using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using frontend.Annotations;
using frontend.API;
using frontend.Commands;
using frontend.Commands.Navigation;
using frontend.Commands.Route;
using frontend.CustomControls;
using frontend.CustomControls.Dialog;
using frontend.Entities;
using frontend.Extensions;
using frontend.Model;
using frontend.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TourService.Entities;

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
            EditRouteCommand = new EditRouteCommand(navigator);
            GeneratePDFCommand = new GeneratePDFCommand(tourService, this);
            CreateLogCommand = new SwitchToCreateLogCommand(navigator);
            EditLogCommand = new EditLogCommand(navigator);
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
                InteractionService.ShowErrorMessageBox("Cant connect to Server");
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