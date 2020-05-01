using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class DealBindingModel
    {
        public int? Id { get; set; }
        public string DealName { get; set; }
        public decimal CountCredit { get; set; }
        public Dictionary<int, (string, int)> DealCredit { get; set; }
    }
}
