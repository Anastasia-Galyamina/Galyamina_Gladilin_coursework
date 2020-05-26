using BankBusinessLogic.Enums;
using System;
using System.ComponentModel;

namespace BankBusinessLogic.ViewModels
{
    public class CreditViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название кредита")]        
        public string CreditName { get; set; }

        [DisplayName("Срок погашения")]
        public String Date { get; set; }

        [DisplayName("Тип")]
        public CreditType Type { get; set; }
    }
}
