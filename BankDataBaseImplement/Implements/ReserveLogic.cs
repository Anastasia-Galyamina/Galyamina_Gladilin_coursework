using BankBusinessLogic.BindingModels;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDataBaseImplement.Implements
{
    public class ReserveLogic : IReservMoney
    {
        public void CreateOrUpdate(ReservedMoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                ResesvedMoney element = context.ResesvedMoney.FirstOrDefault(rec =>
               rec.DealName == model.DealName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.ResesvedMoney.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new ResesvedMoney();
                    context.ResesvedMoney.Add(element);
                }
                element.countMoney = model.countMoney;
                element.ClientId = model.ClientId;
                element.DealId = model.DealId;
                element.DealName = model.DealName;
                context.SaveChanges();
            }
        }

        public void Delete(ReservedMoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                ResesvedMoney element = context.ResesvedMoney.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.ResesvedMoney.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ReservedMoneyViewModel> Read(ReservedMoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.ResesvedMoney
                .Where(rec => model == null || rec.ClientId == model.ClientId)
                .Select(rec => new ReservedMoneyViewModel
                {
                    Id= rec.Id,
                    countMoney=rec.countMoney,                
                    DealName = rec.DealName,
                    DealId = rec.DealId                    
                })
                .ToList();
            }
        }
    }
}
