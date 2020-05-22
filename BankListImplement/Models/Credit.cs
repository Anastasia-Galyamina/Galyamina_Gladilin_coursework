using BankBusinessLogic.Enums;
using System;

namespace BankListImplement.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public string CreditName { get; set; }
        public CreditType Type { get; set; }
        public String Date { get; set; }        
    }
}
