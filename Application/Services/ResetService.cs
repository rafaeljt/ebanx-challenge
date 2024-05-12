using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class ResetService : IResetService
    {
        private readonly ILogger<ResetService> _logger;

        public ResetService(ILogger<ResetService> logger)
        {
            _logger = logger;
        }

        public void ResetState()
        {
            _logger.LogInformation("Resetting state...");
        }
    }
}