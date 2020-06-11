using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class ReportBindingModelAdmin
    {
        public string FileName { get; set; }       
        public List<int> RequestsId { get; set; }
        public string Email { get; set; }
    }
}
