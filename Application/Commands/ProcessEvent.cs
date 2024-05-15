namespace Application.Commands
{
    public class ProcessEvent
    {
        
        public string Type { get; set; }

        public string Origin { get; set; }
        
        public string Destination { get; set; }

        public decimal Amount { get; set; }
    }

    public class EventTypes
    {
        public const string Deposit = "deposit";
        public const string Withdraw = "withdraw";
        public const string Transfer = "transfer";
    }
}