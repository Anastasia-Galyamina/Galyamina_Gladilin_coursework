namespace BankDataBaseImplement.Models
{
    public class MoneyRequest
    {
        public int Id { get; set; }
        public int MoneyId { get; set; }
        public int RequestId { get; set; }
        public int Count { get; set; }
        public virtual Request Request { get; set; }
        public virtual Money Money { get; set; }
    }
}
