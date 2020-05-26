using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BankBusinessLogic.ViewModels
{
    public class CreditViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тип кредита")]
        public string CreditName { get; set; }
        [DisplayName("Сумма Кредита")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> CreditMoney { get; set; }
    }
}
