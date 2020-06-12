using System;
using System.Collections.Generic;
using System.Linq;
using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankRestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly IDealLogic _deal;
        private readonly ICreditLogic _credit;
        private readonly MainLogic _main;
        private readonly ReportLogic _report;
        public MainController(IDealLogic order, ICreditLogic furniture, MainLogic main, ReportLogic report)
        {
            _deal = order;
            _credit = furniture;
            _main = main;         
            _report = report;
        }
        [HttpGet]
        public List<CreditModel> GetCreditList() => _credit.Read(null)?.Select(rec =>
       Convert(rec)).ToList();
        [HttpGet]
        public CreditModel GetCredits(int CreditId) => Convert(_credit.Read(new CreditBindingModel
        {
            Id = CreditId
        })?[0]);
        [HttpGet]
        public List<DealViewModel> GetDeals(int clientId) => _deal.Read(new DealBindingModel
        {
            ClientId = clientId,
            
        });        
        [HttpPost]
        public void SendMessage(ReportBindingModel model) =>_report.SendMessage(model);

        [HttpPost]
        public void CreateDeal(DealBindingModel model) =>
       _main.CreateDeal(model);        
        [HttpPost]
        public void DocCreditDial(ReportBindingModel model) => _report.DocCreditDeal(model);
        [HttpPost]
        public void ExelCreditDial(ReportBindingModel model) => _report.ExelCreditDeal(model);
        [HttpPost]
        [Obsolete]
        public void PdfDialMoney(ReportBindingModel model) => _report.SaveToPdfFile(model);
        private CreditModel Convert(CreditViewModel model)
        {
            if (model == null) return null;
            return new CreditModel
            {
                Id = model.Id,
                CreditName = model.CreditName,
                Price = model.Price,
                Term = model.Term
            };
        }
    }
}