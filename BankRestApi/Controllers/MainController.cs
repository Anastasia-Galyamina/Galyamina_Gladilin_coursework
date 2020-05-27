using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankRestApi.Models;
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
        public MainController(IDealLogic order, ICreditLogic furniture, MainLogic main)
        {
            _deal = order;
            _credit = furniture;
            _main = main;
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
        public void CreateDeal(DealBindingModel model) =>
       _main.CreateOrder(model);
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