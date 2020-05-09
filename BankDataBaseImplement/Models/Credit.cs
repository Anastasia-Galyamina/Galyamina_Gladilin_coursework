using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankDataBaseImplement.Models
{
    public class Credit
    {
        public int Id { get; set; }
        [Required]
        public string CreditName { get; set; }
        [Required]
        public int CountMoney { get; set; }
        public DateTime? DateImplement { get; set; }
        public string currency { get; set; }
        [ForeignKey("CreditId")] public virtual List<DealCredit> DealCredits { get; set; }
    }
}
