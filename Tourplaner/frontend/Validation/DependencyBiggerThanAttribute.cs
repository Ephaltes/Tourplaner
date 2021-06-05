using System;
using System.ComponentModel.DataAnnotations;

namespace frontend.Validation
{
    //https://stackoverflow.com/questions/34765929/testing-a-validation-attribute-that-depends-on-another-property
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DependencyBiggerThanAttribute : ValidationAttribute
    {
        private readonly string _dependendPropertyName;
        private readonly double _greaterThanValue;

        public DependencyBiggerThanAttribute( string dependendPropertyName,double greaterThanValue)
        {
            _greaterThanValue = greaterThanValue;
            _dependendPropertyName = dependendPropertyName;

            if (string.IsNullOrWhiteSpace(ErrorMessage))
                ErrorMessage = $@"Dependend Value is smaller than {greaterThanValue}";
        }

        protected override ValidationResult  IsValid(object value, ValidationContext validationContext)
        {
            var dependendPropertyInfo = validationContext.ObjectType.GetProperty(_dependendPropertyName);
            
            if (dependendPropertyInfo == null)
                throw new ArgumentException("Property with this name not found");
            
            var dependendPropertyValue = dependendPropertyInfo.GetValue(validationContext.ObjectInstance);
            
            if (value != null)
            {
                if (Convert.ToDouble(dependendPropertyValue) <= _greaterThanValue)
                {
                    return new ValidationResult(FormatErrorMessage(this.ErrorMessage));
                }
            }
            return ValidationResult.Success;
        }
    }
}