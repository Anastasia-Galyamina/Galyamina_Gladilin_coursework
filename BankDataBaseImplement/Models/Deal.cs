using BankBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankDataBaseImplement.Models
{
    public class Deal
    {
        public int Id { get; set; }
        [Required]
        public int? ClientId { get; set; }
        [Required]
        public string ClientFIO { get; set; }
        public string DealName { get; set; }
        [Required]
        public DealStatus Status { get; set; }
        public bool? reserved { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<DealCredits> DealCredits { get; set; }
    }
}
