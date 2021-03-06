using System.Windows.Input;
using frontend.ViewModels;

namespace frontend.Navigation
{
    public enum ViewType
    {
        MainWindow,
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}