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

            public void CreateOrder(DealBindingModel model)
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

            public void TakeOrderInWork(ChangeStatusBindingModel model)
            {
            var order = dealLogic.Read(new DealBindingModel { Id = model.DealId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != DealStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            if (storageMoneyLogic.RemoveMaterials(order))
            {
                dealLogic.CreateOrUpdate(new DealBindingModel
                {
                    Id = order.Id,
                    DealName = order.DealName,
                    DealCredits = order.DealCredits,
                    ClientFIO = order.ClientFIO,
                    ClientId = order.ClientId,
                    Status = DealStatus.Подписан
                });
            }
        }
        }
}
