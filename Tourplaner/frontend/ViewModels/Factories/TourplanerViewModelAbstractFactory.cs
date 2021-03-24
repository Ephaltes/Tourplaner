using System;
using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
   
    public class TourplanerViewModelAbstractFactory : ITourplanerViewModelAbstractFactory
    {
        private readonly CreateViewModel<DefaultViewModel> _createDefaultViewModel;
        private readonly CreateViewModel<TestViewModel> _createTestViewModel;

        public TourplanerViewModelAbstractFactory(CreateViewModel<TestViewModel> createTestViewModel,
            CreateViewModel<DefaultViewModel> createDefaultViewModel)
        {
            _createTestViewModel = createTestViewModel;
            _createDefaultViewModel = createDefaultViewModel;
        }


        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Default:
                    return _createDefaultViewModel();
                case ViewType.Test:
                    return _createTestViewModel();
                default:
                    throw new ArgumentException("No ViewModel found");
            }
        }
    }
}