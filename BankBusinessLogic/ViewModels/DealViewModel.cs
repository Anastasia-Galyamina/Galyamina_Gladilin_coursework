using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace BankBusinessLogic.ViewModels
{
    public class DealViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Сделка")]
        public string DealName { set; get; }
        [DataMember]
        public int? ClientId { get; set; }
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }
        public Dictionary<int, (string, int, DateTime?, string)> DealCredit { get; set; }
    }
}
