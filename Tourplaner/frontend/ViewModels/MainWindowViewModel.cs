using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.Navigation;
using frontend.ViewModels.Factories;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {

        public  INavigator _navigator { get; set; }
        private readonly ITourplanerViewModelAbstractFactory _viewModelAbstractFactory;
        
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainWindowViewModel(INavigator navigator, ITourplanerViewModelAbstractFactory viewModelAbstractFactory)
        {
            _navigator = navigator;
            _viewModelAbstractFactory = viewModelAbstractFactory;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_viewModelAbstractFactory,_navigator);
            UpdateCurrentViewModelCommand.Execute(ViewType.Default);
        }

      
    }
}