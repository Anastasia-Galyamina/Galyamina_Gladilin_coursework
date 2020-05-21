using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankDataBaseImplement.Models
{
    public class Money
    {
        public int Id { get; set; }

        [Required] 
        public string currency { get; set; }
        public int sum { get; set; }
        public int reserved { get; set; }

    }
}
