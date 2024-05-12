using Application.Interfaces;
using Application.Queries;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly ILogger<BalanceService> _logger;
        private readonly IAccountService _accountService;

        public BalanceService(ILogger<BalanceService> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public GetBalance GetBalance(GetBalance balance)
        {
            _logger.LogInformation("Getting balance");
            return null;
        }
    }
}