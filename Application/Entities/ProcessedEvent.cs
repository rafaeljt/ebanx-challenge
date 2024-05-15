using Domain.Entities;

namespace Application.Entities
{
    public class ProcessedEvent
    {
        public Account Origin { get; set; }
        public Account Destination { get; set; }
        
    }
}