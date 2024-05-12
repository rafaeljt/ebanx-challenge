using Application.Interfaces;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet("balance")]
        public ActionResult Get([FromQuery(Name = "account_id")] string accountId)
        {
            var balance = _balanceService.GetBalance(new GetBalance(accountId));

            if (balance == null)
            {
                return NotFound(0);
            }
            
            return Ok(balance);
        }
    }
}