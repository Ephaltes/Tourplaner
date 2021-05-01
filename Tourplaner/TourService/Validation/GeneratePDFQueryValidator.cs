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
                .WithMessage("Id is Empty")
                .Must(IdExists)
                .WithMessage("Id does not exist");

        }

        private bool IdExists(int id)
        {
            return true;
        }
    }
}