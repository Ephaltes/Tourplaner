using System;
using System.Windows.Input;
using frontend.ViewModels;

namespace frontend.Navigation
{
    /// <summary>
    /// ViewTypes for switching between Views
    /// </summary>
   public enum ViewType
    {
        Home,
        Settings,
        CreateRoute,
        EditRoute,
        CreateLog,
        EditLog,
        
    } 
   
    /// <summary>
    /// Interface for the Navigator
    /// </summary>
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        public void ChangeViewModel(ViewType viewType);
        event Action StateChanged;
    }
}