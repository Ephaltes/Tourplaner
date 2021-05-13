using FluentValidation;
using TourService.Query;

namespace TourService.Validation
{
    public class GeneratePDFQueryValidator : CustomAbstractValidator<GeneratePDFQuery>
    {
        public GeneratePDFQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is Empty");

        }
    }
}