using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using TourService.Entities;
using TourService.Extensions;
using TourService.Query;
using TourService.Repository;

namespace TourService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
          private readonly IMediator _mediator;
          private readonly NpgsqlConnection _connection;
          public LogController(IMediator mediator, NpgsqlConnection connection)
          {
              _mediator = mediator;
              _connection = connection;
          }

          [HttpGet] 
          [Route("{id}")]
          public async Task<IActionResult> GetLogs(int id)
          {
              var query = new GetLogsQuery(id);
              var response = await _mediator.Send(query);
              return response.ToResponse();
          }
    }
}