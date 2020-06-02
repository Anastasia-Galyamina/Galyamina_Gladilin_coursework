using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankBusinessLogic.BindingModels;
using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankDataBaseImplement.Implements;
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
        private readonly IReservMoney _reserveLogic;
        public MainController(IDealLogic order, ICreditLogic furniture, MainLogic main, IReservMoney reserveLogic)
        {
            _deal = order;
            _credit = furniture;
            _main = main;
            _reserveLogic = reserveLogic;
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
        [HttpGet]
        public List<ReservedMoneyViewModel> GetReservedMoney(int clientId) => _reserveLogic.Read(new ReservedMoneyBindingModel
        {
            ClientId = clientId,
        });

        [HttpPost]
        public void CreateDeal(DealBindingModel model) =>
       _main.CreateOrder(model);
        [HttpPost]
        public void ReservMoney(ReservedMoneyBindingModel model) =>
      _reserveLogic.CreateOrUpdate(model);
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
        private DealBindingModel Convert(DealViewModel model)
        {
            if (model == null) return null;
            return new DealBindingModel
            {
               Id = model.Id,
               ClientId = model.ClientId,
               ClientFIO = model.ClientFIO,
               DealCredits = model.DealCredits,
               DealName = model.DealName,
               Status = model.Status
            };
        }
    }
}