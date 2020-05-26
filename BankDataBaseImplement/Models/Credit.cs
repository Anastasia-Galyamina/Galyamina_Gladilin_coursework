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
        public decimal Price { get; set; }
        [ForeignKey("CreditId")]
        public virtual List<Deal> Deals { get; set; }
        [ForeignKey("CreditId")]
        public virtual List<CreditMoney> CreditMoney { get; set; }
    }
}
