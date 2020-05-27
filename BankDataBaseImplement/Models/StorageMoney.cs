using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankDataBaseImplement.Models
{
    public class StorageMoney
    {
        public int Id { set; get; }
        public int StorageId { set; get; }
        public int MoneyId { set; get; }
        [Required]
        public int Count { set; get; }
        public virtual Storage Storage { set; get; }
        public virtual Money Money { set; get; }
    }
}
