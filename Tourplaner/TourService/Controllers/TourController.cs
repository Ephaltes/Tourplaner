using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TourService.Command;
using TourService.Entities;
using TourService.Extensions;

namespace TourService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TourController : ControllerBase
    {
          private readonly IMediator _mediator;
          public TourController(IMediator mediator)
          {
              _mediator = mediator;
          }
          
          [HttpPost]
          public async Task<IActionResult> GenerateRoutePDF([FromBody] GenerateRoutePDFCommand entity)
          {
              var result = await _mediator.Send(entity);
              return result.ToResponse();
          }
    }
}