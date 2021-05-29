using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Npgsql;
using Serilog;
using TourService.Query;
using TourService.Repository;

namespace TourService.Validation
{
    public class GeneratePDFQueryValidator : CustomAbstractValidator<GeneratePDFQuery>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ILogger _logger = Log.ForContext<RouteRepository>();
        public GeneratePDFQueryValidator(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
            
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Id is Empty")
                .MustAsync(IdExists)
                .WithMessage("Id does not Exist");
        }

        private async Task<bool> IdExists(int id, CancellationToken token)
        {
            try
            {
                var ret = await _routeRepository.Get(id);
                return ret != null;
            }
            catch (NpgsqlException e)
            {
                _logger.Error(e.Message);
                return false;
            }
        }
    }
}