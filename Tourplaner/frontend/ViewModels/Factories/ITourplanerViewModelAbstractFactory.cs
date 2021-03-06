using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
    public interface ITourplanerViewModelAbstractFactory
    {
        public ViewModelBase CreateViewModel(ViewType viewType);
    }
}