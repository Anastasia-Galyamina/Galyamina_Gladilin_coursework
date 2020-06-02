using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankRestApi.Models
{
    public class CreditModel
    {
        public int? Id { get; set; }
        public string CreditName { get; set; }
        public decimal Price { get; set; }
        public string Term { get; set; }
    }
}
