using System;
using System.Collections.Generic;


namespace BankBusinessLogic.BindingModels
{
    public class DealBindingModel
    {
        public int? Id { get; set; }
        public string DealName { set; get; }
        public int ClientId { get; set; }    
        public DateTime Date { get; set; }
        public Dictionary<int, (string, int)> DealCredits { get; set; }
    }
}
