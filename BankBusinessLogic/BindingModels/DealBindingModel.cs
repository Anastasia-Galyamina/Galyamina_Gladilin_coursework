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
        public string DealName { set; get; }
        public Dictionary<int, (string, int, DateTime?,string)> DealCredits { get; set; }
    }
}
