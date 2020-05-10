using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BankBusinessLogic.ViewModels
{
    public class DealViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Сделка")]
        public string DealName { set; get; }
        public Dictionary<int, (string, int, DateTime?, string)> DealCredit { get; set; }
    }
}
