using BankBusinessLogic.Enums;
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
        [DisplayName("Срок погашения")]
        public DateTime? Date { get; set; }
        [DisplayName("Тип")]
        public CreditType Type { get; set; }
    }
}
