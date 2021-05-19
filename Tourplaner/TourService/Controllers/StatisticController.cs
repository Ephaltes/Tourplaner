using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Serilog;
using TourService.Entities;
using TourService.Extensions;
using TourService.Query;
using TourService.Repository;

namespace TourService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticController : ControllerBase
    {
          private readonly IMediator _mediator;
          private readonly ILogger _logger = Log.ForContext<RoutePdfController>();

          public StatisticController(IMediator mediator)
          {
              _mediator = mediator;
          }
          
          [HttpGet]
          public async Task<IActionResult> GenerateRoutePDF()
          {
              _logger.Debug($"Creating Statistic-Report");
              var query = new GenerateStatisticQuery();
              var result = await _mediator.Send(query);
              return result.ToResponse();
          }
    }
}