namespace BankBusinessLogic.BindingModels
{
    public class StorageMoneyBindingModel
    {
        public int Id { set; get; }
        public int MoneyId { set; get; }       
        public int Count { set; get; }
        public decimal? Reserved { set; get; }       
    }
}
