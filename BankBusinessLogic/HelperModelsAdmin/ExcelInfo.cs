using BankBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BankBusinessLogic.HelperModelsAdmin
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDealViewModel> Deals { get; set; }
    }
}
