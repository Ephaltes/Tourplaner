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
    public class UpdateLogCommandValidator : CustomAbstractValidator<UpdateLogCommand>
    {
        private readonly ILogger _logger = Log.ForContext<RouteRepository>();
        public UpdateLogCommandValidator()
        {
            
            RuleFor(x => x.Entity.Id)
                .GreaterThan(0)
                .WithMessage("Invalid Id");

            RuleFor(x => x.Entity.Destination)
                .NotEmpty()
                .WithMessage("Destination is Empty");
            
            RuleFor(x => x.Entity.Distance)
                .GreaterThan(0)
                .WithMessage("Distance is Empty");
            
            RuleFor(x => x.Entity.Origin)
                .NotEmpty()
                .WithMessage("Origin is Empty");
            
            RuleFor(x => x.Entity.Rating)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Destination is Empty");
            
            RuleFor(x => x.Entity.Route_id)
                .GreaterThan(0)
                .WithMessage("Not associated with a Route");

            RuleFor(x => x.Entity.EndDate)
                .NotEmpty()
                .WithMessage("EndDate is Empty")
                .GreaterThanOrEqualTo(x => x.Entity.StartDate)
                .WithMessage("StartDate is bigger than EndDate");
            
            RuleFor(x => x.Entity.EndTime)
                .NotEmpty()
                .WithMessage("EndTime is Empty");
            
            RuleFor(x => x.Entity.StartDate)
                .NotEmpty()
                .WithMessage("StartDate is Empty");
            
            RuleFor(x => x.Entity.StartTime)
                .NotEmpty()
                .WithMessage("StartTime is Empty");
            
            RuleFor(x => x.Entity.BPM)
                .GreaterThan(0)
                .WithMessage("BPM is invalid")
                .LessThanOrEqualTo(250)
                .WithMessage("BPM is invalid");
        }
       
    }
}