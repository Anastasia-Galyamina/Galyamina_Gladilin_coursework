using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BankBusinessLogic.ViewModels
{
    public class DealViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название сделки")]
        public string DealName { get; set; }
        [DisplayName("Количество кредитов")]
        public decimal CountCredit { get; set; }
        public Dictionary<int, (string, int)> DealCredit { get; set; }
    }
}
