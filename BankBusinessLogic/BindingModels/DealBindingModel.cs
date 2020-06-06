using BankBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class DealBindingModel
    {
        public int? Id { get; set; }
        public string DealName { get; set; }
        public int? ClientId { get; set; }
        public string ClientFIO { set; get; }
        public DealStatus Status { get; set; }
        public Dictionary<int, (string, DateTime?)> DealCredits { get; set; }
    }
}
