using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Interfaсes;
using BankBusinessLogic.ViewModels;
using BankDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDataBaseImplement.Implements
{
    public class MoneyLogic : IMoneyLogic
    {
        public void CreateOrUpdate(MoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                Money element = context.Money.FirstOrDefault(rec =>
               rec.currency == model.currency && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Money.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Money();
                    context.Money.Add(element);
                }
                element.currency = model.currency;
                context.SaveChanges();
            }
        }

        public List<MoneyViewModel> Read(MoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.Money
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new MoneyViewModel
                {
                    Id = rec.Id,
                    currency = rec.currency
                })
                .ToList();
            }
        }
        public void Delete(MoneyBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
