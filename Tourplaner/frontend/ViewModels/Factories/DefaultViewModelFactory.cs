using frontend.Navigation;

namespace frontend.ViewModels.Factories
{
    public class DefaultViewModelFactory : IViewModelFactory<DefaultViewModel>
    {

        public DefaultViewModel CreateViewModel()
        {
            return new DefaultViewModel();
        }
    }
}