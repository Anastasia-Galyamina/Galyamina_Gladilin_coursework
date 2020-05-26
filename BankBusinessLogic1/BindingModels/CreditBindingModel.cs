using BankBusinessLogic.Enums;
using System;


namespace BankBusinessLogic.BindingModels
{
    public class CreditBindingModel
    {
        public int? Id { get; set; }
        public string CreditName { get; set; }        
        public String Date { get; set; }
        public CreditType Type { get; set; }
    }
}
