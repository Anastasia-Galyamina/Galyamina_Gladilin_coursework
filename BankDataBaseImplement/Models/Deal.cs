using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankDataBaseImplement.Models
{
    public class Deal
    {
        public int? Id { get; set; }
        [Required]
        public string DealName { set; get; }
        public int? ClientId { get; set; }
        [Required]
        public string ClientFIO { get; set; }
        public virtual Client Client { set; get; }
        public virtual List<DealCredit> DealCredits { get; set; }
    }
}
