using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankDataBaseImplement.Models
{
    public class CreditMoney
    {
        public int Id { get; set; }
        public int CreditId { get; set; }
        public int MoneyId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Credit Credit { get; set; }
        public virtual Money Money { get; set; }
    }
}
