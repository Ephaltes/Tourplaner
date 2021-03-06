using System;
using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
    public class TourplanerViewModelAbstractFactory : ITourplanerViewModelAbstractFactory
    {
        private readonly IViewModelFactory<MainWindowViewModel> _mainWindowViewModel;

        public TourplanerViewModelAbstractFactory(IViewModelFactory<MainWindowViewModel> mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.MainWindow:
                    return _mainWindowViewModel.CreateViewModel();
                default:
                    throw new ArgumentException("No ViewModel found");
            }
        }
    }
}