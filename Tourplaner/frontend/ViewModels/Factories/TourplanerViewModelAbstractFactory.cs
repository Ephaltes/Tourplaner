using System;
using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
   
    public class TourplanerViewModelAbstractFactory : ITourplanerViewModelAbstractFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<SettingsViewModel> _createSettingsViewModel;
        private readonly CreateViewModel<UpSertRouteViewModel> _createUpSertViewModel;

        public TourplanerViewModelAbstractFactory(CreateViewModel<HomeViewModel> createHomeViewModel, CreateViewModel<SettingsViewModel> createSettingsViewModel,
            CreateViewModel<UpSertRouteViewModel> createUpSertViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createSettingsViewModel = createSettingsViewModel;
            _createUpSertViewModel = createUpSertViewModel;
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
                    return _createUpSertViewModel();
                default:
                    throw new ArgumentException("No ViewModel found");
            }
        }
    }
}