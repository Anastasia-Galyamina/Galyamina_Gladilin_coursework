using BankBusinessLogic.BindingModels;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDataBaseImplement.Implements
{
    public class CreditLogic : ICreditLogic
    {
        public void CreateOrUpdate(CreditBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Credit credit = context.Credits.FirstOrDefault(rec => rec.CreditName == model.CreditName && rec.Id != model.Id);
                        if (credit != null)
                        {
                            throw new Exception("Уже есть кредит с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            credit = context.Credits.FirstOrDefault(rec => rec.Id == model.Id);
                            if (credit == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            credit = new Credit();
                            context.Credits.Add(credit);
                        }
                        credit.CreditName = model.CreditName;
                        credit.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.CreditMoney.Where(rec => rec.CreditId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.CreditMoney.RemoveRange(productComponents.Where(rec => !model.FurnitureComponents.ContainsKey(rec.MoneyId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count = model.FurnitureComponents[updateComponent.MoneyId].Item2;
                                model.FurnitureComponents.Remove(updateComponent.MoneyId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.FurnitureComponents)
                        {
                            context.CreditMoney.Add(new CreditMoney
                            {
                                CreditId = credit.Id,
                                MoneyId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(CreditBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по кредитам при удалении сделки
                        context.CreditMoney.RemoveRange(context.CreditMoney.Where(rec => rec.CreditId == model.Id));
                        Credit element = context.Credits.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Credits.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<CreditViewModel> Read(CreditBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.Credits.Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new CreditViewModel
                {
                    Id = rec.Id,
                    CreditName = rec.CreditName,
                    Price = rec.Price,
                    CreditMoney = context.CreditMoney.Include(recPC => recPC.Money)
                                                           .Where(recPC => recPC.CreditId == rec.Id)
                                                           .ToDictionary(recPC => recPC.MoneyId, recPC => (recPC.Money?.Currency, recPC.Count))
                }).ToList();
            }
        }
    }
}
