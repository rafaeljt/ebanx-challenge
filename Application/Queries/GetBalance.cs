namespace Application.Queries
{
    public class GetBalance
    {
        public string AccountId { get; set; }

        public GetBalance(string accountId)
        {
            AccountId = accountId;
        }
    }
}