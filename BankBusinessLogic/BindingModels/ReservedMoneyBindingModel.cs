using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class ReservedMoneyBindingModel
    {
        public int? Id { get; set; }
        public int DealId { get; set; }
        public string DealName { get; set; }
        public decimal countMoney { get; set; }
        public int ClientId { get; set; }
    }
}
