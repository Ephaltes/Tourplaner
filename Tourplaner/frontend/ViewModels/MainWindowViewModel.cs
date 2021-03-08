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

        private readonly INavigator _navigator;
        private readonly ITourplanerViewModelAbstractFactory _viewModelAbstractFactory;
        
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainWindowViewModel(INavigator navigator, ITourplanerViewModelAbstractFactory viewModelAbstractFactory)
        {
            _navigator = navigator;
            _navigator.StateChanged += NavigatorOnStateChanged;
            _viewModelAbstractFactory = viewModelAbstractFactory;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_viewModelAbstractFactory,_navigator);
            UpdateCurrentViewModelCommand.Execute(ViewType.Default);
        }

        private void NavigatorOnStateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}