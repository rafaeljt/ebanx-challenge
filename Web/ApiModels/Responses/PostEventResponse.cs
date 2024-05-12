namespace Web.ApiModels.Responses
{
    public class PostEvent
    {
        public Origin Origin { get; set; }

        public Destination Destination { get; set; }
        
    }
    
    public class Origin
    {
        public string Id { get; set; }

        public long Balance { get; set; }
    }

    public class Destination
    {
        public string Id { get; set; }

        public long Balance { get; set; }
    }
}