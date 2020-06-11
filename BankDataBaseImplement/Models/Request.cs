using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDataBaseImplement.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime DateCreation { get; set; }            
        public string Email { get; set; }

        [ForeignKey("RequestId")]
        public virtual List<MoneyRequest> MoneyRequests { get; set; }
    }
}
