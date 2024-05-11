using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class EventController : ControllerBase
    {
        [HttpPost]
        public Task<ActionResult> Get()
        {
            return Task.FromResult<ActionResult>(Ok("blockedIds"));
        }
    }
}