using System;
using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
    public class TourplanerViewModelAbstractFactory : ITourplanerViewModelAbstractFactory
    {
        private readonly IViewModelFactory<DefaultViewModel> _defaultViewModel;
        private readonly IViewModelFactory<TestViewModel> _testViewModel;

        public TourplanerViewModelAbstractFactory( IViewModelFactory<TestViewModel> testViewModel, IViewModelFactory<DefaultViewModel> defaultViewModel)
        {
            _testViewModel = testViewModel;
            _defaultViewModel = defaultViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Default:
                    return _defaultViewModel.CreateViewModel();
                case ViewType.TestView:
                    return _testViewModel.CreateViewModel();
                default:
                    throw new ArgumentException("No ViewModel found");
            }
        }
    }
}