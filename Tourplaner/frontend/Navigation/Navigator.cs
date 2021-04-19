using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Commands;
using frontend.ViewModels;
using frontend.ViewModels.Factories;
using Serilog;

namespace frontend.Navigation
{
    public class Navigator : INavigator
    {
        private ViewModelBase _currentViewModel;
        private ITourplanerViewModelAbstractFactory _tourplanerViewModelAbstractFactory;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                Log.Debug("Navigator CurrentViewModel Set");
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        public Navigator(ITourplanerViewModelAbstractFactory tourplanerViewModelAbstractFactory)
        {
            _tourplanerViewModelAbstractFactory = tourplanerViewModelAbstractFactory;
        }

        public void ChangeViewModel(ViewType viewType)
        {
            CurrentViewModel = _tourplanerViewModelAbstractFactory.CreateViewModel(viewType);
        }
        
        public event Action StateChanged;
    }
}