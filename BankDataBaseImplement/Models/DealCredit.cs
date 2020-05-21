using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankDataBaseImplement.Models
{
    public class DealCredit
    {
        public int Id { get; set; }
        public int? DealId { get; set; }
        public int CreditId { get; set; }
        [Required]
        public int Sum { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public string currency { get; set; }
        public virtual Credit Credit { get; set; }
        public virtual Deal Deal { get; set; }

       
    }
}
