using System;
using System.Collections.Generic;
using System.Text;

namespace BankListImplement.Models
{
    public class DealCredit
    {
        public int Id { get; set; }
        public int DealId { get; set; }
        public int MoneyId { get; set; }
        public int Count { get; set; }
    }
}
