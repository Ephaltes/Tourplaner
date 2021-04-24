using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.Commands.Button_Menu;
using frontend.Commands.Navigation;
using frontend.Navigation;
using frontend.ViewModels.Factories;
using Serilog;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {

        private readonly INavigator _navigator;
        private string _resizeIconPath;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand CloseApplication { get; }
        public ICommand MinimizeApplication { get; }
        public ICommand ResizeApplication { get; }

        public string ResizeIconPath
        {
            get => _resizeIconPath;
            set
            {
                Log.Debug("ResizeIconPath Set");
                _resizeIconPath = value;
                OnPropertyChanged(nameof(ResizeIconPath));
            }
        }


        public MainWindowViewModel(INavigator navigator)
        {
            Log.Debug("CTOR MainWindowViewModel");
            _navigator = navigator;
            _navigator.StateChanged += NavigatorOnStateChanged;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator);
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
            ResizeIconPath = Constants.MaximizePath;
            CloseApplication = new CloseApplicationCommand();
            MinimizeApplication = new MinimizeApplicationCommand();
            ResizeApplication = new ResizeApplicationCommand(this);

        }

        private void NavigatorOnStateChanged()
        {
            Log.Debug("NavigatorChanged");
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}