namespace Web.ApiModels.Responses
{
    public class PostEvent
    {
        public Account Origin { get; set; }

        public Account Destination { get; set; }

    }

    public class Account
    {
        public string Id { get; set; }

        public long Balance { get; set; }
    }
}
