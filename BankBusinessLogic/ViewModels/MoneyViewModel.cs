using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BankBusinessLogic.ViewModels
{
    public class MoneyViewModel
    {
        public int Id { get; set; }
        [DisplayName("Валюта")]
        public string Currency { get; set; }
    }
}
