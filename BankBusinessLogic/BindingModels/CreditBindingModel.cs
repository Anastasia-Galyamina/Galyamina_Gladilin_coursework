namespace BankBusinessLogic.BindingModels
{
    public class CreditBindingModel
    {
        public int? Id { get; set; }
        public string CreditName { get; set; }
        public decimal Price { get; set; }
        public string Term { get; set; }
        public string Currency { get; set; }        
    }
}
