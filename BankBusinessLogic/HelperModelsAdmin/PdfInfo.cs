using BankBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BankBusinessLogic.HelperModelsAdmin
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportRequestViewModel> Requests { get; set; }
        public List<ReportCreditsViewModel> Credits { get; set; }
    }
}
