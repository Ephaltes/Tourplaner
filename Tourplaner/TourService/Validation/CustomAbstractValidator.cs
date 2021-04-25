using FluentValidation;

namespace TourService.Validation
{
    public class CustomAbstractValidator<T>:AbstractValidator<T>
    {
        public CustomAbstractValidator()
        {
            CascadeMode = CascadeMode.Stop;
        }
    }
}