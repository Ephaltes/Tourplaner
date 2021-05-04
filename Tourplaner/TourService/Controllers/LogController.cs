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
          
          [HttpPost] 
          public async Task<IActionResult> CreateLog([FromBody] CreateLogCommand command)
          {
              var response = await _mediator.Send(command);
              return response.ToResponse();
          }
          
          [HttpPut] 
          public async Task<IActionResult> UpdateLog([FromBody] UpdateLogCommand command)
          {
              var response = await _mediator.Send(command);
              return response.ToResponse();
          }
          
          [HttpDelete] 
          [Route("{id}")]
          public async Task<IActionResult> Get(int id)
          {
              var cmd = new DeleteLogCommand(id);
              var response = await _mediator.Send(cmd);
              return response.ToResponse();
          }
          
    }
}