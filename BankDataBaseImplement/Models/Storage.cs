using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankDataBaseImplement.Models
{
    public class Storage
    {
        public int Id { set; get; }
        [Required]
        public string StorageName { set; get; }
        [ForeignKey("StorageId")]
        public virtual List<StorageMoney> StorageMoney { set; get; }
    }
}
