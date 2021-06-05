using System;
using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
   
    public class TourplanerViewModelAbstractFactory : ITourplanerViewModelAbstractFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<SettingsViewModel> _createSettingsViewModel;
        private readonly CreateViewModel<CreateRouteViewModel> _createRouteViewModel;
        private readonly CreateViewModel<EditRouteViewModel> _createEditRouteViewModel;
        private readonly CreateViewModel<UpSertLogViewModel> _upsertLogViewModel;

        public TourplanerViewModelAbstractFactory(CreateViewModel<HomeViewModel> createHomeViewModel, CreateViewModel<SettingsViewModel> createSettingsViewModel,
            CreateViewModel<CreateRouteViewModel> createRouteViewModel, CreateViewModel<EditRouteViewModel> createEditRouteViewModel, CreateViewModel<UpSertLogViewModel> upsertLogViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createSettingsViewModel = createSettingsViewModel;
            _createRouteViewModel = createRouteViewModel;
            _createEditRouteViewModel = createEditRouteViewModel;
            _upsertLogViewModel = upsertLogViewModel;
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
                case ViewType.CreateLog:
                case ViewType.EditLog:
                    return _upsertLogViewModel();
                default:
                    throw new ArgumentException("No ViewModel found");
            }
        }
    }
}