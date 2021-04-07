using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.Navigation;
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

            TestCommand = new IncreaseCountCommand(this);

            Routes = new ObservableCollection<Route>();
            Routes.Add(new Route { Name = "Route2Route2Route2Route2Route2", Description = "beschreibung", Id = 2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 }); 
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 }); 
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 }); 
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 }); 
            Routes.Add(new Route { Name = "Route2", Description = "beschreibung", Id = 2 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });
            Routes.Add(new Route { Name = "Route3", Description = "beschreibung", Id = 3 });

            SelectedRoute = Routes[5];
        }
    }
}