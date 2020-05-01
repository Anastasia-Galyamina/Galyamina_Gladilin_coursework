using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class CreateDealBindingModel
    {
        public int? Id { get; set; }  
        public Dictionary<int, CreditType> DealCredit { get; set; }
    }
}
