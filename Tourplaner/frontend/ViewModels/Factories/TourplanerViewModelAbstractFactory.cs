using System;
using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
   
    public class TourplanerViewModelAbstractFactory : ITourplanerViewModelAbstractFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<SettingsViewModel> _createSettingsViewModel;

        public TourplanerViewModelAbstractFactory(CreateViewModel<HomeViewModel> createHomeViewModel, CreateViewModel<SettingsViewModel> createSettingsViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createSettingsViewModel = createSettingsViewModel;
        }


        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Settings:
                    return _createSettingsViewModel();
                default:
                    throw new ArgumentException("No ViewModel found");
            }
        }
    }
}