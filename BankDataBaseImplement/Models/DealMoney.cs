namespace BankDataBaseImplement.Models
{
    public class DealMoney
    {
        public int Id { get; set; }
        public int MoneyId { get; set; }
        public int CreditId { get; set; }
        public virtual Credit Credit { get; set; }
        public virtual Money Money { get; set; }
    }
}
