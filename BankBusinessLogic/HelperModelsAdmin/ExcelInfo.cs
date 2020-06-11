using BankBusinessLogic.ViewModels;

namespace BankBusinessLogic.HelperModelsAdmin
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public RequestViewModel Request { get; set; }
    }
}
