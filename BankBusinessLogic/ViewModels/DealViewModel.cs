using BankBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace BankBusinessLogic.ViewModels
{
    public class DealViewModel
    {
        public int Id { get; set; }
        [DataMember]
        public int? ClientId { get; set; }
        [DisplayName("Сделка")]
        public string DealName { get; set; }
        [DisplayName("Статус")]
        public DealStatus Status { get; set; }
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }
        [DisplayName("Зарезервированы деньги")]
        public bool? reserved { get; set; }
        public Dictionary<int, (string, DateTime?)> DealCredits { get; set; }
        public int CreditId { get; set; }
    }
}
