using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BankBusinessLogic.ViewModels
{
    public class CreditViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название кредита")]
        public string CreditName { get; set; }
        [DisplayName("Сумма кредита")]
        public int CountMoney { get; set; }
        [DisplayName("Дата погашения")]
        public DateTime? DateImplement { get; set; }
        [DisplayName("Валюта")]
        public string currency { get; set; }
    }
}
