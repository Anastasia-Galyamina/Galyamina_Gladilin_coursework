using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class ReportAdminBindingModel
    {
        public string FileName { get; set; }       
        public List<RequestBindingModel> Requests { get; set; }
        public List<CreditBindingModel> Credits { get; set; }       
    }
}
