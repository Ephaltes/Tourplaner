using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using frontend.Annotations;

namespace frontend.ViewModels
{
    public delegate T CreateViewModel<T>() where T : ViewModelBase;

    /// <summary>
    /// Base ViewModel
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public virtual void Dispose()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
