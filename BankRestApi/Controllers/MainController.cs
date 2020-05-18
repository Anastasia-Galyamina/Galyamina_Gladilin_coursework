using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusinessLogic;
using BankBusinessLogic.Interfaсes;
using BankBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
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
        public MainController(IDealLogic deal, ICreditLogic credit, MainLogic main)
        {
            _deal = deal;
            _credit = credit;
            _main = main;
        }
        [HttpGet]
        public List<CreditModel> GetCreditList() => _credit.Read(null)?.Select(rec =>
       Convert(rec)).ToList();
        [HttpGet]
        public CreditModel GetCredit(int FurnitureId) => Convert(_credit.Read(new CreditBindingModel
        {
            Id = FurnitureId
        })?[0]);
        [HttpGet]
        public List<DealViewModel> GetDeals(int clientId) => _deal.Read(new DealBindingModel
        {
            ClientId = clientId
        });
        [HttpPost]
        public void CreateOrder(CreateDealBindingModel model) =>
       _main.CreateOrder(model);
        private CreditModel Convert(CreditViewModel model)
        {
            if (model == null) return null;
            return new CreditModel
            {
                Id = model.Id,
                CreditName = model.CreditName,
                CountMoney = model.CountMoney,
                currency = model.currency,
                DateImplement = model.DateImplement
            };
        }
    }
}