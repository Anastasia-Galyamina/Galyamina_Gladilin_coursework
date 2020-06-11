using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDataBaseImplement.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public int MoneyId { get; set; }
        [Required]
        public string CreditName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public String currency { get; set; }
        public string Term { get; set; }
        [ForeignKey("CreditId")]
        public virtual List<DealCredits> DealCredits { get; set; }      
        public virtual Money Money { get; set; }
    }
}
