using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TourService.Command;
using TourService.Extensions;
using TourService.Query;

namespace TourService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
          private readonly IMediator _mediator;
          public LogController(IMediator mediator)
          {
              _mediator = mediator;
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