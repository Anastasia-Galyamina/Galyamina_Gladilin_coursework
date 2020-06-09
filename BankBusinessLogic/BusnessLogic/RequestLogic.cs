using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.HelperModelsAdmin;
using BankBusinessLogic.ViewModels;
using System.Net;
using System.Net.Mail;


namespace BankDataBaseImplement.Implements
{ 
    public class RequestLogic
    {

        /*private readonly IDealLogic dealLogic;
        private readonly ICreditLogic creditLogic;
        private readonly IMoneyLogic moneyLogic;

        public ReportLogic(IDealLogic dealLogic, ICreditLogic creditLogic, IMoneyLogic moneyLogic)
        {
            this.dealLogic = dealLogic;
            this.creditLogic = creditLogic;
            this.moneyLogic = moneyLogic;
        }*/
        /*public List<MoneyViewModel> Read(MoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.Money
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new MoneyViewModel
                {
                    Id = rec.Id,
                    Currency = rec.Currency
                })
                .ToList();
            }
        }*/

        public RequestViewModel GetRequest(RequestBindingModel model)
        {
            var viewModel = new RequestViewModel();
            viewModel.Id = model.Id;
            viewModel.DateCreation = model.DateCreation;
            viewModel.Email = model.Email;            
           viewModel.MoneyCount = model.MoneyCount;
            
            return viewModel;
        }        
        public void DocRequest(RequestBindingModel model)
        {
            SaveToWordAdmin.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Заявки на деньги",
                Request = GetRequest(model)
            });
        }
        /*public void ExelCreditDeal(ReportBindingModel model)
        {
            SaveToExcelClient.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Сделки",
                Deals = GetDeals(model)
            });
        }
        [Obsolete]
        public void SaveToPdfFile(ReportBindingModel model)
        {
            SaveToPdfClient.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список сделок",
                Deals = GetDealsMoney(model)
            });
        }*/
        public void SendMessage(ReportBindingModel model)
        {
            MailAddress from = new MailAddress("labwork15kafis@gmail.com");
            MailAddress to = new MailAddress(model.Email);
            MailMessage m = new MailMessage(from, to);
            m.Attachments.Add(new Attachment(model.FileName));
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("labwork15kafis@gmail.com", "passlab15");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
