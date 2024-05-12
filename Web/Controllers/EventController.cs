using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ApiModels.Requests;

namespace Web.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("event")]
        public ActionResult Post([FromBody] PostEventRequest eventRequest)
        {
            var processedEvent = _eventService.ProcessEvent(eventRequest);

            if (processedEvent == null)
            {
                return NotFound(0);
            }

            return Created("", processedEvent);
        }
    }
}