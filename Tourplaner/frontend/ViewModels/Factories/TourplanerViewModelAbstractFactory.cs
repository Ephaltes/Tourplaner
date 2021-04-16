using System;
using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
   
    public class TourplanerViewModelAbstractFactory : ITourplanerViewModelAbstractFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<SettingsViewModel> _createSettingsViewModel;
        private readonly CreateViewModel<CreateRouteViewModel> _createRouteViewModel;
        private readonly CreateViewModel<UpSertLogViewModel> _createUpSertLogViewModel;
        private readonly CreateViewModel<EditRouteviewModel> _createEditRouteViewModel;

        public TourplanerViewModelAbstractFactory(CreateViewModel<HomeViewModel> createHomeViewModel, CreateViewModel<SettingsViewModel> createSettingsViewModel,
            CreateViewModel<CreateRouteViewModel> createRouteViewModel,CreateViewModel<UpSertLogViewModel> createUpSertLogViewModel, CreateViewModel<EditRouteviewModel> createEditRouteViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createSettingsViewModel = createSettingsViewModel;
            _createRouteViewModel = createRouteViewModel;
            _createUpSertLogViewModel = createUpSertLogViewModel;
            _createEditRouteViewModel = createEditRouteViewModel;
        }


        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Settings:
                    return _createSettingsViewModel();
                case ViewType.CreateRoute:
                    return _createRouteViewModel();
                case ViewType.EditRoute:
                    return _createEditRouteViewModel();
                case ViewType.UpSertLog:
                    return _createUpSertLogViewModel();
                default:
                    throw new ArgumentException("No ViewModel found");
            }
        }
    }
}