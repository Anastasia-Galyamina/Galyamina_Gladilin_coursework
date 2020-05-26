using System.ComponentModel;

namespace BankBusinessLogic.ViewModels
{
    public class MoneyViewModel
    {
        public int Id { get; set; }

        [DisplayName("Валюта")]
        public string currency { get; set; }
    }
}
