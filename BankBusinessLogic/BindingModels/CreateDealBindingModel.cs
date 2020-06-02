using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class CreateDealBindingModel
    {
        [DataMember]
        public int CreditId { get; set; }
        [DataMember]
        public string ClientFIO { set; get; }
        [DataMember]
        public int ClientId { get; set; }
        public DateTime date { get; set; }
    }
}
