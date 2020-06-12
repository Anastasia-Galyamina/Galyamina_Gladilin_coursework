using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Enums;
using BankBusinessLogic.InterFaces;
using System;

namespace BankBusinessLogic.BusnessLogic
{
        public class MainLogic
        {
            private readonly IDealLogic dealLogic;
            private readonly IStorageMoneyLogic storageMoneyLogic;
            public MainLogic(IDealLogic dealLogic,IStorageMoneyLogic storageMoneyLogic)
            {
                this.dealLogic = dealLogic;
                this.storageMoneyLogic = storageMoneyLogic;
            }

            public void CreateDeal(DealBindingModel model)
            {
                dealLogic.CreateOrUpdate(new DealBindingModel
                {
                    Id = model.Id,
                    DealName = model.DealName,
                    ClientId = model.ClientId,
                    ClientFIO = model.ClientFIO,
                    DealCredits = model.DealCredits,
                    Status = DealStatus.Принят
                });
            }

            public void TakDealInWork(ChangeStatusBindingModel model)
            {
            var deal = dealLogic.Read(new DealBindingModel { Id = model.DealId })?[0];
            if (deal == null)
            {
                throw new Exception("Не найдена сделка");
            }
            if (deal.Status != DealStatus.Принят)
            {
                throw new Exception("Сделка не в статусе \"Принят\"");
            }
            if (storageMoneyLogic.RemoveMaterials(deal))
            {
                storageMoneyLogic.CancelReservation(deal);
                dealLogic.CreateOrUpdate(new DealBindingModel
                {
                    Id = deal.Id,
                    DealName = deal.DealName,
                    DealCredits = deal.DealCredits,
                    ClientFIO = deal.ClientFIO,
                    ClientId = deal.ClientId,
                    Status = DealStatus.Подписан
                });
            }
        }
        }
}
