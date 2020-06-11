using BankBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BankBusinessLogic.HelperModelsAdmin
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportRequestViewModel> Requests { get; set; }
        public List<KeyValuePair<int, (string, string, string, string, System.DateTime?, string, decimal)>> Credits { get; set; }
    }
}
