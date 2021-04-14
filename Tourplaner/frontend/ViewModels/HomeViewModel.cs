using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.CustomControls.Dialog;
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

        public ObservableCollection<Route> Routes { get; set; }
        private Route _selectedRoute;
        public Route SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                Log.Debug("_selectedRoute Set");
                _selectedRoute = value;
                OnPropertyChanged(nameof(SelectedRoute));
            }
        }

        public ICommand TestCommand { get; set; }
      
        public HomeViewModel()
        {
            Log.Debug("CTOR HomeViewModel");

            TestCommand = new IncreaseCountCommand();

            List<Route> log = new List<Route>();
            log.Add(new Route { Name = "Route1", Description = "beschreibung", Id = 3 });
            log.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 3 });
            log.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            log.Add(new Route { Name = "Route4", Description = "beschreibung", Id = 3 }); 
            log.Add(new Route { Name = "Route5", Description = "beschreibung", Id = 3 });

            List<Route> log2 = new List<Route>();
            log2.Add(new Route { Name = "Route21", Description = "beschreibung", Id = 3 });
            log2.Add(new Route { Name = "Route22", Description = "beschreibung", Id = 3 });
            log2.Add(new Route { Name = "Route23", Description = "beschreibung", Id = 3 });
            log2.Add(new Route { Name = "Route24", Description = "beschreibung", Id = 3 });
            log2.Add(new Route { Name = "Route25", Description = "beschreibung", Id = 3 });

            Routes = new ObservableCollection<Route>();
            Routes.Add(new Route { Name = "Route2Route2Route2Route2Route2", Description = "beschreibung", Id = 2, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log }); 
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log }); 
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log }); 
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log }); 
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3, Log = log });

            SelectedRoute = Routes[5];
        }
    }
}