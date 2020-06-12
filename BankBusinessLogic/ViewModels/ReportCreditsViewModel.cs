using System;

namespace BankBusinessLogic.ViewModels
{
    public class ReportCreditsViewModel
    {
        public int Id { get; set; }
        public string DealName { get; set; }
        public string ClientFio { get; set; }
        public string CreditName { get; set; }
        public string Term { get; set; }       
        public string Currency { get; set; }
        public decimal Price { get; set; }
    }
}
