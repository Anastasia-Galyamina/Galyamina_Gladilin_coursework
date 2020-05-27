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
                        Credit element = context.Credits.FirstOrDefault(rec => rec.CreditName == model.CreditName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Credits.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Credit();
                            context.Credits.Add(element);
                        }
                        element.CreditName = model.CreditName;
                        element.Price = model.Price;
                        element.Term = model.Term;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.CreditMoney.Where(rec => rec.CreditId == model.Id.Value).ToList();
                            context.CreditMoney.RemoveRange(productComponents.Where(rec => !model.CreditMoney.ContainsKey(rec.MoneyId)).ToList());
                            context.SaveChanges();
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count = model.CreditMoney[updateComponent.MoneyId].Item2;
                                model.CreditMoney.Remove(updateComponent.MoneyId);
                            }
                            context.SaveChanges();
                        }
                        foreach (var pc in model.CreditMoney)
                        {
                            context.CreditMoney.Add(new CreditMoney
                            {
                                CreditId = element.Id,
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
                    Term = rec.Term,
                    CreditMoney = context.CreditMoney.Include(recPC => recPC.Money)
                                                           .Where(recPC => recPC.CreditId == rec.Id)
                                                           .ToDictionary(recPC => recPC.MoneyId, recPC => (recPC.Money?.Currency, recPC.Count))
                }).ToList();
            }
        }
    }
}
