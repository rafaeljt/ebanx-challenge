using Application.Interfaces;
using Application.Queries;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly ILogger<BalanceService> _logger;

        public BalanceService(ILogger<BalanceService> logger)
        {
            _logger = logger;
        }

        public GetBalance GetBalance(GetBalance balance)
        {
            _logger.LogInformation("Getting balance");
            return null;
        }
    }
}