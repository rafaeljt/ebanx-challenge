using Application.Commands;
using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class EventService : IEventService
    {
        private readonly ILogger<EventService> _logger;
        private readonly IAccountService _accountService;

        public EventService(ILogger<EventService> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public ProcessEvent ProcessEvent(ProcessEvent @event)
        {
            _logger.LogInformation("Processing event");
            return null;
        }
    }
}