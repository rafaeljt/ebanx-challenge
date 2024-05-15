using Application.Commands;

namespace Web.ApiModels.Requests
{
    public class PostEventRequest
    {
        public string Type { get; set; }

        public string Origin { get; set; }
        
        public string Destination { get; set; }

        public long Amount { get; set; }

        public static implicit operator ProcessEvent(PostEventRequest postEventRequest)
        {
            return new ProcessEvent()
            {
                Amount = postEventRequest.Amount,
                Origin = postEventRequest.Origin,
                Destination = postEventRequest.Destination,
                Type = postEventRequest.Type
            };
        }
    }
}