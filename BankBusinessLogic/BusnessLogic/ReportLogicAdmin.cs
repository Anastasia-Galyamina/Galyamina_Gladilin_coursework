using BankBusinessLogic.BindingModels;
using BankBusinessLogic.HelperModelsAdmin;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace BankBusinessLogic.BusnessLogic
{
    public class ReportLogicAdmin
    {
        private readonly IRequestLogic requestLogic;
        private readonly IMoneyLogic moneyLogic;

        public ReportLogicAdmin(IRequestLogic requestLogic, IMoneyLogic moneyLogic)
        {
            this.requestLogic = requestLogic;
            this.moneyLogic = moneyLogic;
        }       
        public List<ReportRequestViewModel> GetRequestsMoney(ReportBindingModelAdmin model)
        {
            var list = new List<ReportRequestViewModel>();
            if (model.RequestsId == null)
            {
                return null;
            }
            foreach (var RequestId in model.RequestsId)
            {
                var money = moneyLogic.Read(null);
                var requests = requestLogic.ReadRequests(new RequestBindingModel()
                {
                    Id = RequestId
                });
                foreach (var request in requests)
                {
                    foreach (var currency in money)
                    {
                        if (request.MoneyCount.ContainsKey(currency.Currency))
                        {
                            var record = new ReportRequestViewModel
                            {
                                RequestId = request.Id,
                                Count = money.Count,
                                Currency = currency.Currency,
                                Email = request.Email                                
                            };
                            list.Add(record);
                        }
                    }
                }
            }
            return list;
        }        
        [Obsolete]
        public void SaveToPdfFile(ReportBindingModelAdmin model)
        {
            SaveToPdfAdmin.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заявок",
                Requests = GetRequestsMoney(model)
            });
        }
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
