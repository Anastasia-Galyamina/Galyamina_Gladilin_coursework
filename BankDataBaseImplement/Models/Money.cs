using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankDataBaseImplement.Models
{
    public class Money
    {
        public int Id { get; set; }
        [Required]
        public string Currency { get; set; }
        [ForeignKey("MoneyId")]
        public virtual List<CreditMoney> CreditMoney { get; set; }
        [ForeignKey("MoneyId")]
        public virtual List<StorageMoney> StorageMoney { get; set; }
    }
}
