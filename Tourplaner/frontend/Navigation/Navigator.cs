using System;
using frontend.ViewModels;
using frontend.ViewModels.Factories;
using Serilog;

namespace frontend.Navigation
{
    public class Navigator : INavigator
    {
        private ViewModelBase _currentViewModel;
        private ITourplanerViewModelAbstractFactory _tourplanerViewModelAbstractFactory;
        private readonly ILogger _logger = Log.ForContext<Navigator>();


        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _logger.Debug("Navigator CurrentViewModel Set");
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