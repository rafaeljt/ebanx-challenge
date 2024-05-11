using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class BalanceController : ControllerBase
    {
        
        [HttpGet]
        public Task<ActionResult> Get()
        {
            return Task.FromResult<ActionResult>(Ok("blockedIds"));
        }
    }
}