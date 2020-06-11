using System.ComponentModel;

namespace BankBusinessLogic.ViewModels
{
    public class CreditViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тип кредита")]
        public string CreditName { get; set; }
        [DisplayName("Сумма Кредита")]
        public decimal Price { get; set; }
        [DisplayName("Срок погашения")]
        public string Term { get; set; }

        [DisplayName("Валюта")]
        public string Currency { get; set; }       
    }
}
