using System;
using System.Collections.Generic;
using System.Text;

namespace BankListImplement.Models
{
    public class DealCredit
    {
        public int Id { get; set; }
        public int DealId { get; set; }
        public int CreditId { get; set; }
        public int Count { get; set; }
        public DateTime? dateImplement { get; set; }
        public string currency { get; set; }
    }
}
