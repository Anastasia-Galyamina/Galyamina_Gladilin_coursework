using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.HelperModelsClient
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDealMoneyViewModel> Deals { get; set; }
    }
}
