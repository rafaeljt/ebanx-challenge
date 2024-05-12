namespace Application.Commands
{
    public class ProcessEvent
    {
        public string Type { get; set; }

        public string Destination { get; set; }

        public long Amount { get; set; }
    }
}