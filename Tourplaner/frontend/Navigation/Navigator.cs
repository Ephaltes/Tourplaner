using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Commands;
using frontend.ViewModels;
using frontend.ViewModels.Factories;

namespace frontend.Navigation
{
    public class Navigator : INavigator , INotifyPropertyChanged
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public Navigator(ITourplanerViewModelAbstractFactory viewModelAbstractFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(viewModelAbstractFactory,this);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}