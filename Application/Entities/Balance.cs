namespace Application.Entities
{
    public class Balance
    {
        public decimal Value { get; set; }

        public Balance(decimal value)
        {
            Value = value;
        }
    }
}