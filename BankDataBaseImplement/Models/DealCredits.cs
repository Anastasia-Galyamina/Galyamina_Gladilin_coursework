using System;

namespace BankDataBaseImplement.Models
{
    public class DealCredits
    {
        public int Id { get; set; }
        public int DealId { get; set; }
        public int CreditId { get; set; }        
        public DateTime? dateImplement { get; set; }
        public virtual Credit Credit { get; set; }
        public virtual Deal Deal { get; set; }
    }
}
