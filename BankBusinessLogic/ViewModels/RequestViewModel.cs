using System.Collections.Generic;
using System;

namespace BankBusinessLogic.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }        
        public DateTime DateCreation { get; set; }
        public Dictionary<String, int> MoneyCount { get; set; }
        public string Email { get; set; }
    }
}
