using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Commands;
using frontend.ViewModels;
using frontend.ViewModels.Factories;

namespace frontend.Navigation
{
    public class Navigator : INavigator
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;

        public Navigator()
        {
        }
    }
}