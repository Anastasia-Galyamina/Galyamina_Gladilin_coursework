using BankBusinessLogic.BindingModels;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankDataBaseImplement.Implements
{
    public class MoneyLogic : IMoneyLogic
    {
        public void CreateOrUpdate(MoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                Money element = context.Money.FirstOrDefault(rec =>
               rec.Currency == model.Currency && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть валюта с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Money.FirstOrDefault(rec => rec.Id == model.Id);
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
                element.Currency = model.Currency;
                context.SaveChanges();
            }
        }

        public void Delete(MoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                Money element = context.Money.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Money.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
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
                    Currency = rec.Currency
                })
                .ToList();
            }
        }
    }
}
