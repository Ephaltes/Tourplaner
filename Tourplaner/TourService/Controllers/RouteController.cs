using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using TourService.Entities;
using TourService.Extensions;
using TourService.Repository;

namespace TourService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
          private readonly IMediator _mediator;
          private readonly NpgsqlConnection _connection;
          public RouteController(IMediator mediator, NpgsqlConnection connection)
          {
              _mediator = mediator;
              _connection = connection;
          }
          
          [HttpPost]
          public async Task<IActionResult> GenerateRoutePDF()
          {
              return Ok();
          }

          [HttpGet]
          public async Task<IActionResult> Test()
          {
              var test = new RouteRepository(_connection);
              return Ok();
          }
    }
}