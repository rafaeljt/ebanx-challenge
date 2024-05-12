using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class ResetService : IResetService
    {
        private readonly ILogger<ResetService> _logger;
        private readonly IAccountService _accountService;

        public ResetService(ILogger<ResetService> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public void ResetState()
        {
            _logger.LogInformation("Resetting state...");
            _accountService.ResetRecords();
        }
    }
}