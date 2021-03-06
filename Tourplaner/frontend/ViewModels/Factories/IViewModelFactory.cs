namespace frontend.ViewModels.Factories
{
    public interface IViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}