using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using TourService.Command;
using TourService.Entities;
using TourService.Extensions;
using TourService.Query;
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
          public async Task<IActionResult> UpSertRoute([FromBody] UpSertRouteCommand cmd)
          {
              var response = await _mediator.Send(cmd);
              return response.ToResponse();
          }

          [HttpGet] 
          [Route("{id}")]
          public async Task<IActionResult> Get(int id,bool withLogs = false)
          {
              var query = new GetRouteQuery(id,withLogs);
              var response = await _mediator.Send(query);
              return response.ToResponse();
          }
          [HttpGet]
          public async Task<IActionResult> GetAll(bool withLogs = false)
          {
              var query = new GetAllRoutesQuery(withLogs);
              var response = await _mediator.Send(query);
              return response.ToResponse();
          }
    }
}