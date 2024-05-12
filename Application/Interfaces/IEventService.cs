using Application.Commands;

namespace Application.Interfaces
{
    public interface IEventService
    {
        public ProcessEvent ProcessEvent(ProcessEvent @event);
    }
}