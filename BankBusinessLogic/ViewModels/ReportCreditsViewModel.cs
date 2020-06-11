using System;

namespace BankBusinessLogic.ViewModels
{
    public class ReportCreditsViewModel
    {
        public string DealName { get; set; }
        public string ClientFIO { get; set; }
        public string CreditName { get; set; }
        public DateTime Date { get; set; }
        public String Currency { get; set; }
        public int Sum { get; set; }

    }
}
