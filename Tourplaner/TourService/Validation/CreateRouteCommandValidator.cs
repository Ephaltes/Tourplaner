using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Npgsql;
using Serilog;
using TourService.Command;
using TourService.Query;
using TourService.Repository;

namespace TourService.Validation
{
    public class CreateRouteCommandValidator : CustomAbstractValidator<CreateRouteCommand>
    {
        private readonly ILogger _logger = Log.ForContext<RouteRepository>();
        public CreateRouteCommandValidator()
        {

            RuleFor(x => x.Entity.Description)
                .NotEmpty()
                .WithMessage("Description is empty");
            
            RuleFor(x => x.Entity.Destination)
                .NotEmpty()
                .WithMessage("Destination is empty");

            RuleFor(x => x.Entity.Name)
                .NotEmpty()
                .WithMessage("Name is empty");
            
            RuleFor(x => x.Entity.Origin)
                .NotEmpty()
                .WithMessage("Origin is empty");

            RuleFor(x => x.Entity.ImageSource)
                .NotEmpty()
                .WithMessage("No Image found");
        }
       
    }
}