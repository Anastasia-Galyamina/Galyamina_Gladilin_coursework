using BankBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class CreditBindingModel
    {
        public int? Id { get; set; }
        public string CreditName { get; set; }        
        public DateTime? Date { get; set; }
        public CreditType Type { get; set; }
    }
}
