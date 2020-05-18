using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankRestApi
{
    public class CreditModel
    {
        public int Id { get; set; }
        [Required]
        public string CreditName { get; set; }
        [Required]
        public int CountMoney { get; set; }
        public DateTime? DateImplement { get; set; }
        public string currency { get; set; }
    }
}
