using System;
using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
   
    public class TourplanerViewModelAbstractFactory : ITourplanerViewModelAbstractFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;

        public TourplanerViewModelAbstractFactory(CreateViewModel<HomeViewModel> createHomeViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
        }


        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                default:
                    throw new ArgumentException("No ViewModel found");
            }
        }
    }
}