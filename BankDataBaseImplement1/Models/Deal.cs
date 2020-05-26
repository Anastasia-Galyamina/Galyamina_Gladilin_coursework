using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDataBaseImplement.Models
{
    public class Deal
    {
        public int Id { get; set; }
        [Required]
        public string DealName { set; get; } 
        [Required]
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("DealId")]
        public virtual List<DealCredit> DealCredits { get; set; }

        [ForeignKey("DealId")]
        public virtual List<DealMoney> DealMoney { get; set; }
    }
}
