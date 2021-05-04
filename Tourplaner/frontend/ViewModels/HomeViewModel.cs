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

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class HomeViewModel : ViewModelBase
    {
        internal ObservableCollection<RouteModel> Routes { get; set; }
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
                Log.Debug("_selectedRoute Set");
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
                Log.Debug("Set searchtext");
                if (value == SearchText) return;
                _searchText = value;
                OnFilterChanged();
            }
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }
        public ICommand DeleteRouteCommand { get; set; }
        public ICommand EditRouteCommand { get; set; }
        public ICommand GeneratePDFCommand { get; set; }        
      
        public HomeViewModel(INavigator navigator,ITourService tourService, IUserInteractionService interactionService)
        {
            Log.Debug("CTOR HomeViewModel");
            _tourService = tourService;
            InteractionService = interactionService;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator);
            DeleteRouteCommand = new DeleteRouteCommand(this,tourService);
            EditRouteCommand = new EditRouteCommand(navigator);
            GeneratePDFCommand = new GeneratePDFCommand(tourService, this);
            
            Routes = new ObservableCollection<RouteModel>(tourService.GetAllRoutes().Result.ToModel(tourService).OrderByDescending(a=>a.Id));
            SelectedRoute = Routes.FirstOrDefault();
            // var directions = new List<string>();
            // directions.Add("vorne");
            // directions.Add("hinten");
            // directions.Add("rechts");
            // directions.Add("links");
            //
            // var route = new RouteModel(tourService)
            // {
            //     Description = "",
            //     Destination = "Destination",
            //     Id = 1,
            //     Name = "Name of Tour",
            //     Origin = "Origin",
            //     Directions = directions,
            // };
            // route.ImageSource = File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/placeholder.png");
            //
            // var route2 = new RouteModel(tourService)
            // {
            //     Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.\n" +
            //     "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, \n" +
            //     "when an unknown printer took a galley of type and scrambled it to make a type specimen book. \n" +
            //     "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.\n" +
            //     " It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages,\n" +
            //     "and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            //     Destination = "Destination2",
            //     Id = 2,
            //     Name = "Name of Tour2",
            //     Origin = "Origin2",
            //     Directions = directions,
            // };
            // var client = new WebClient();
            // route2.ImageSource = client.DownloadData("http://chriscavanagh.files.wordpress.com/2006/12/chriss-blog-banner.jpg");
            //
            // Routes = new ObservableCollection<RouteModel>();
            // Routes.Add(route2);
            // Routes.Add(route);
            // Routes.Add(route2);
            // Routes.Add(route);
            // Routes.Add(route);
            // Routes.Add(route);
            // Routes.Add(route);
            // Routes.Add(route);
            // Routes.Add(route);
            // Routes.Add(route);
            // Routes.Add(route);
            // Routes.Add(route); 
            // Routes.Add(route);
            // Routes.Add(route); 
            //
            // SelectedRoute = Routes[5];

            CvsRoute = new CollectionViewSource();
            CvsRoute.Source = Routes;
            CvsRoute.Filter += CvsRouteOnFilter;
        }

        //https://stackoverflow.com/questions/12188623/implementing-a-listview-filter-with-josh-smiths-wpf-mvvm-demo-app
        private void CvsRouteOnFilter(object sender, FilterEventArgs e)
        {
           Log.Debug("Filter");
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