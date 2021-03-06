using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.Navigation;

namespace frontend.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public INavigator Navigator { get; set; }
        
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set => _selectedViewModel = value;
        }

        private int _countIncreaseValue = 1;
        private string _countValue;
        public string CountValue
        {
            get => _countValue;
            set
            {
                _countValue = value;
                OnPropertyChanged(nameof(CountValue));
            }
        }
        public int CountIncreaseValue
        {
            get => _countIncreaseValue;
            set
            {
                _countIncreaseValue = value;
                OnPropertyChanged(nameof(CountIncreaseValue));
            } 
        }
        public ICommand IncreaseCountCommand { get; }

        public MainWindowViewModel()
        {
            IncreaseCountCommand = new IncreaseCountCommand(this);
        }
    }
}