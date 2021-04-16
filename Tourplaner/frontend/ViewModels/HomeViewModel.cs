using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.CustomControls.Dialog;
using frontend.Entities;
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

        public ObservableCollection<RouteEntity> Routes { get; set; }
        private RouteEntity _selectedRoute;
        public RouteEntity SelectedRoute
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

            List<RouteEntity> log = new List<RouteEntity>();
            log.Add(new RouteEntity { Name = "Route1", Description = "beschreibung", Id = 3 });
            log.Add(new RouteEntity { Name = "Route2", Description = "beschreibung", Id = 3 });
            log.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3 });
            log.Add(new RouteEntity { Name = "Route4", Description = "beschreibung", Id = 3 }); 
            log.Add(new RouteEntity { Name = "Route5", Description = "beschreibung", Id = 3 });

            List<RouteEntity> log2 = new List<RouteEntity>();
            log2.Add(new RouteEntity { Name = "RouteEntity21", Description = "beschreibung", Id = 3 });
            log2.Add(new RouteEntity { Name = "RouteEntity22", Description = "beschreibung", Id = 3 });
            log2.Add(new RouteEntity { Name = "Route23", Description = "beschreibung", Id = 3 });
            log2.Add(new RouteEntity { Name = "Route24", Description = "beschreibung", Id = 3 });
            log2.Add(new RouteEntity { Name = "Route25", Description = "beschreibung", Id = 3 });

            Routes = new ObservableCollection<RouteEntity>();
            Routes.Add(new RouteEntity { Name = "Route2Route2Route2Route2Route2", Description = "beschreibung", Id = 2 });
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3}); 
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3}); 
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3}); 
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route2", Description = "beschreibung", Id = 2});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route2", Description = "beschreibung", Id = 2});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route2", Description = "beschreibung", Id = 2});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route2", Description = "beschreibung", Id = 2});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route2", Description = "beschreibung", Id = 2});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route2", Description = "beschreibung", Id = 2});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route2", Description = "beschreibung", Id = 2});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3}); 
            Routes.Add(new RouteEntity { Name = "Route2", Description = "beschreibung", Id = 2});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});
            Routes.Add(new RouteEntity { Name = "Route3", Description = "beschreibung", Id = 3});

            SelectedRoute = Routes[5];
        }
    }
}