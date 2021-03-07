using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using frontend.Annotations;
using frontend.Commands;
using frontend.Navigation;
using frontend.ViewModels.Factories;

namespace frontend.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class DefaultViewModel : ViewModelBase
    {

        
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

        public DefaultViewModel()
        {
            IncreaseCountCommand = new IncreaseCountCommand(this);
        }
    }
}