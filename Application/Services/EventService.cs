using Application.Commands;
using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class EventService : IEventService
    {
        private readonly ILogger<EventService> _logger;

        public EventService(ILogger<EventService> logger)
        {
            _logger = logger;
        }

        public ProcessEvent ProcessEvent(ProcessEvent @event)
        {
            _logger.LogInformation("Processing event");
            return null;
        }
    }
}