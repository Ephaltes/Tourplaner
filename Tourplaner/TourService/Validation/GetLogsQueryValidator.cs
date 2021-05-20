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
    public class GetLogsQueryValidator : CustomAbstractValidator<GetLogsQuery>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly ILogger _logger = Log.ForContext<RouteRepository>();
        public GetLogsQueryValidator(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
            
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is Empty")
                .MustAsync(RouteExists)
                .WithMessage("Route does not exist");
        }

        private async Task<bool> RouteExists(int id, CancellationToken token)
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