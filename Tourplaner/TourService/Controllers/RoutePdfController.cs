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
    public class RoutePdfController : ControllerBase
    {
          private readonly IMediator _mediator;
          public RoutePdfController(IMediator mediator)
          {
              _mediator = mediator;
          }
          
          [HttpGet]
          [Route("{id}")]
          public async Task<IActionResult> GenerateRoutePDF(int id)
          {
              Log.Debug($"Creating Report for Route Id: {id}");
              var query = new GeneratePDFQuery(id);
              var result = await _mediator.Send(query);
              return result.ToResponse();
          }
    }
}