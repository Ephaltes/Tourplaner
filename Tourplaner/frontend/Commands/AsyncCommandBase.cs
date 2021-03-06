using System;
using System.Threading.Tasks;
using System.Windows.Input;
using frontend.Annotations;

namespace frontend.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private bool _isRunning;
        public bool IsRunning{
            get => _isRunning;
            set
            {
                _isRunning = value;
                OnCanExecuteChanged();
            }
        }
        
        public bool CanExecute(object? parameter)
        {
            return !_isRunning;
        }

        public async void Execute(object? parameter)
        {
            IsRunning = true;

            await ExecuteAsync(parameter);

            IsRunning = false;
        }
        
        public abstract Task ExecuteAsync([CanBeNull] object parameter);

        public event EventHandler? CanExecuteChanged;
        
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}