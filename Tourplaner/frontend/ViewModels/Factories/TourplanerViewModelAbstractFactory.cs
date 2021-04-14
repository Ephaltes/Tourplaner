using System;
using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
   
    public class TourplanerViewModelAbstractFactory : ITourplanerViewModelAbstractFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<SettingsViewModel> _createSettingsViewModel;
        private readonly CreateViewModel<UpSertRouteViewModel> _createUpSertRouteViewModel;
        private readonly CreateViewModel<UpSertLogViewModel> _createUpSertLogViewModel;

        public TourplanerViewModelAbstractFactory(CreateViewModel<HomeViewModel> createHomeViewModel, CreateViewModel<SettingsViewModel> createSettingsViewModel,
            CreateViewModel<UpSertRouteViewModel> createUpSertRouteViewModel,CreateViewModel<UpSertLogViewModel> createUpSertLogViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createSettingsViewModel = createSettingsViewModel;
            _createUpSertRouteViewModel = createUpSertRouteViewModel;
            _createUpSertLogViewModel = createUpSertLogViewModel;
        }


        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Settings:
                    return _createSettingsViewModel();
                case ViewType.UpSertRoute:
                    return _createUpSertRouteViewModel();
                case ViewType.UpSertLog:
                    return _createUpSertLogViewModel();
                default:
                    throw new ArgumentException("No ViewModel found");
            }
        }
    }
}