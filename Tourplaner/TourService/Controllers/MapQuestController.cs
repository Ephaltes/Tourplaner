using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TourService.Extensions;
using TourService.Query;

namespace TourService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapQuestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MapQuestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{from}/{to}/{language?}")]
        public async Task<IActionResult> GetMapQuestRouteInformation(string from, string to,string language="en_US")
        {
            var query = new GetMapQuestRouteInformationQuery(from,to,language);
            var response = await _mediator.Send(query);
            return response.ToResponse();
        }
    }
}