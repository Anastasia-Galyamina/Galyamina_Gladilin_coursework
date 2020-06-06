using System;
using System.Collections.Generic;
using System.Text;

namespace BankDataBaseImplement.Models
{
    public class ResesvedMoney
    {
        public int? Id { get; set; }
        public int DealId { get; set; }
        public string DealName { get; set; }
        public decimal countMoney { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
