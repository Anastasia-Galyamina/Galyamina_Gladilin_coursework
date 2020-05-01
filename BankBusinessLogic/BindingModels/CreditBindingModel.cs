using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class CreditBindingModel
    {
        public int? Id { get; set; }
        public string CreditName { get; set; }
        public int CountMoney { get; set; }
        public DateTime? DateImplement { get; set; }
        public string currency { get; set; }
    }
}
