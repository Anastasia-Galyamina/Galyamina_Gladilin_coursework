using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class CreditBindingModel
    {
        public int? Id { get; set; }
        public string CreditName { get; set; }
        public decimal Price { get; set; }
        public string Term { get; set; }
        public Dictionary<int, (string, int)> CreditMoney { get; set; }
    }
}
