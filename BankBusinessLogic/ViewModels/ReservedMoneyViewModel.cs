using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace BankBusinessLogic.ViewModels
{
    public class ReservedMoneyViewModel
    {
        public int? Id { get; set; }
        public int DealId { get; set; }
        [DataMember]
        [DisplayName("Сделка")]
        public string DealName { get; set; }
        [DataMember]
        [DisplayName("Количество денег")]
        public decimal countMoney { get; set; }

    }
}
