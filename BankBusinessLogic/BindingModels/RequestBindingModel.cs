using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class RequestBindingModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime DateCreation { get; set; }
        public Dictionary<String, int> MoneyCount { get; set; }
        public string Email { get; set; }
    }
}
