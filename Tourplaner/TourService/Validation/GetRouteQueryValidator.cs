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
    public class GetRouteQueryValidator : CustomAbstractValidator<GetRouteQuery>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ILogger _logger = Log.ForContext<RouteRepository>();
        public GetRouteQueryValidator(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
            
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is Empty")
                .MustAsync(IdExists)
                .WithMessage("Route does not Exists");
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