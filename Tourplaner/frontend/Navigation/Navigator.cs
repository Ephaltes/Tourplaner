using System.Windows.Input;
using frontend.Commands;
using frontend.ViewModels;
using frontend.ViewModels.Factories;

namespace frontend.Navigation
{
    public class Navigator : INavigator
    {
        public ViewModelBase CurrentViewModel { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; set; }
        
        public Navigator(ITourplanerViewModelAbstractFactory viewModelAbstractFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(viewModelAbstractFactory,this);
        }
    }
}