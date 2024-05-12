using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class ResetController : ControllerBase
    {
        private readonly IResetService _resetService;

        public ResetController(IResetService resetService)
        {
            _resetService = resetService;
        }

        [HttpPost("reset")]
        public ActionResult Post()
        {
            _resetService.ResetState();
            return Ok();
        }
    }
}