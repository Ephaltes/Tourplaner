using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace frontend.ViewModels
{
    public class ErrorViewModel : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _propertyErrorList = new();
        public bool HasErrors => _propertyErrorList.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyErrorList.GetValueOrDefault(propertyName, null);
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrorList.ContainsKey(propertyName))
                _propertyErrorList.Add(propertyName, new List<string>());

            _propertyErrorList[propertyName].Add(errorMessage);
            OnErrorChanged(propertyName);
        }
        
        public void AddError(string propertyName, List<string> errorMessages)
        {
            _propertyErrorList[propertyName] = errorMessages;
            OnErrorChanged(propertyName);
        }

        public void ClearErrors(string propertyName)
        {
            if (_propertyErrorList.Remove(propertyName))
                OnErrorChanged(propertyName);
        }

        private void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            //OnPropertyChanged(nameof(HasErrors));
        }
        
        public void Validate(object val, object ViewModel, [CallerMemberName] string propertyName = null)
        {
            if (_propertyErrorList.ContainsKey(propertyName)) ClearErrors(propertyName);
 
            ValidationContext context = new ValidationContext(ViewModel) { MemberName = propertyName };
            List<ValidationResult> results = new();
 
            if (!Validator.TryValidateProperty(val, context, results))
            {
                AddError(propertyName, results.Select(x => x.ErrorMessage).ToList());
            }
            OnErrorChanged(propertyName);
        }
    }
}