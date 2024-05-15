using Application.Commands;
using Application.Entities;

namespace Application.Interfaces
{
    public interface IEventService
    {
        public ProcessedEvent ProcessEvent(ProcessEvent @event);
    }
}