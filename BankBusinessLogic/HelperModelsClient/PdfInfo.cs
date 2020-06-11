using BankBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BankBusinessLogic.HelperModelsClient
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDealMoneyViewModel> Deals { get; set; }        

    }
}
