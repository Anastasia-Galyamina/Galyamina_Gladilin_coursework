using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Enums;
using BankBusinessLogic.InterFaces;
using System;

namespace BankBusinessLogic.BusnessLogic
{
        public class MainLogic
        {
            private readonly IDealLogic dealLogic;
            private readonly IStorageLogic storageLogic;

            public MainLogic(IDealLogic dealLogic, IStorageLogic storageLogic)
            {
                this.dealLogic = dealLogic;
                this.storageLogic = storageLogic;
            }

            public void CreateOrder(CreateDealBindingModel model)
            {
                dealLogic.CreateOrUpdate(new DealBindingModel
                {
                    CreditId = model.CreditId,
                    Count = model.Count,
                    Sum = model.Sum,
                    DateCreate = DateTime.Now,
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
                if (storageLogic.RemoveMoney(order))
                {
                    if (order.Status != DealStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    dealLogic.CreateOrUpdate(new DealBindingModel
                    {
                        Id = order.Id,
                        CreditId = order.CreditId,
                        Count = order.Count,
                        Sum = order.Sum,
                        DateCreate = order.DateCreate,
                        DateImplement = DateTime.Now,
                        Status = DealStatus.Выполняется
                    });
                }
            }

            public void FinishOrder(ChangeStatusBindingModel model)
            {
                var order = dealLogic.Read(new DealBindingModel { Id = model.DealId})?[0];
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != DealStatus.Выполняется)
                {
                    throw new Exception("Заказ не в статусе \"Выполняется\"");
                }
                dealLogic.CreateOrUpdate(new DealBindingModel
                {
                    Id = order.Id,
                    CreditId = order.CreditId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    Status = DealStatus.Готов
                });
            }

            public void PayOrder(ChangeStatusBindingModel model)
            {
                var order = dealLogic.Read(new DealBindingModel { Id = model.DealId })?[0];
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != DealStatus.Готов)
                {
                    throw new Exception("Заказ не в статусе \"Готов\"");
                }
                dealLogic.CreateOrUpdate(new DealBindingModel
                {
                    Id = order.Id,
                    CreditId = order.CreditId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    Status = DealStatus.Оплачен
                });
            }

            public void AddMaterials(StorageAddMoneyBindingModel model)
            {
                storageLogic.AddMaterialToStorage(model);
            }
        }
}
