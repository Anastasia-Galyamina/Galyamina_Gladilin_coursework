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
    public class MoneyLogic : IMoneyLogic
    {
        public void CreateOrUpdate(MoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                Money money = context.Money.FirstOrDefault(rec =>
               rec.Currency == model.Currency && rec.Id != model.Id);
                if (money != null)
                {
                    throw new Exception("Уже есть такая валюта");
                }
                if (model.Id.HasValue)
                {
                    money = context.Money.FirstOrDefault(rec => rec.Id == model.Id);
                    if (money == null)
                    {
                        throw new Exception("Валюта не найдена");
                    }
                }
                else
                {
                    money = new Money();
                    context.Money.Add(money);
                }
                money.Currency = model.Currency;
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
                    throw new Exception("Валюта не найдена");
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
