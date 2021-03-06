namespace frontend.ViewModels.Factories
{
    public class MainViewModelFactory : IViewModelFactory<MainWindowViewModel>
    {
        public MainWindowViewModel CreateViewModel()
        {
            return new MainWindowViewModel();
        }
    }
}