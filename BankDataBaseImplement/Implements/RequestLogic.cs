using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.HelperModelsAdmin;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace BankDataBaseImplement.Implements
{
    public class RequestLogic : IRequestLogic
    {
        public List<RequestViewModel> ReadRequests(RequestBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.Request.Where(rec => model == null || (rec.Id == model.Id ) ||
                (rec.Email == model.Email))
                .ToList()
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    Email = rec.Email,
                    DateCreation = rec.DateCreation,                    
                    MoneyCount = context.MoneyRequest.Include(recPC => recPC.Money)
                                                           .Where(recPC => recPC.RequestId == rec.Id)
                                                           .ToDictionary( recPC => recPC.Money.Currency, recPc => recPc.Count)
                }).ToList();
            }
        }
        public void Save(RequestViewModel model)
        {
            using (var context = new BankDataBase())
            {
                Request request = new Request();
                context.Request.Add(request);                
                request.Email = model.Email;
                request.DateCreation = model.DateCreation;
                context.SaveChanges();

                foreach (var currency in model.MoneyCount)
                {
                    MoneyRequest moneyRequest = new MoneyRequest();
                    context.MoneyRequest.Add(moneyRequest);                   
                    moneyRequest.MoneyId = context.Money.FirstOrDefault(rec => rec.Currency == currency.Key).Id;
                    moneyRequest.RequestId = request.Id;
                    moneyRequest.Count = currency.Value;

                    //добавление денег на склад по заявке
                    StorageMoney storage = context.StorageMoney.FirstOrDefault(rec => rec.Money.Currency == currency.Key);
                    if(storage != null)
                    {
                        storage.Count += currency.Value;                       
                    }
                                    
                    
                }
                context.SaveChanges();
            }
        }

        public int GetId()
        {
            using (var context = new BankDataBase())
            {
                int id = context.Request.Count() + 1;
                return id;
            }
        }
        public Dictionary<string, int> Read()
        {
            using (var context = new BankDataBase())
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                foreach(var money in context.StorageMoney)
                {
                    if (money.Reserved != 0 && (money.Reserved - money.Count) > 0)
                    {
                        string currency = context.Money.FirstOrDefault(rec => rec.Id == money.MoneyId).Currency;
                        dict.Add(currency, Convert.ToInt32(money.Reserved - money.Count));
                    }
                        
                }
                return dict;
            }            
        }

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
                Title = "Заявка на деньги",
                Request = GetRequest(model)
            });
        }
        public void ExelRequest(RequestBindingModel model)
        {
            SaveToExcelAdmin.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Заявка на деньги",
                Request = GetRequest(model)
            });
        }       
        public void SendMessage(RequestBindingModel model)
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
