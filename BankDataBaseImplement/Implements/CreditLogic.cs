using BankBusinessLogic.BindingModels;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
                            throw new Exception("Уже есть кредит с таким названием");
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
                        element.currency = model.Currency;
                        element.Term = model.Term;
                        element.MoneyId = context.Money.FirstOrDefault(rec => rec.Currency == model.Currency).Id;
                        context.SaveChanges();                        
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
                    Currency = rec.currency                   
                }).ToList();
            }
        }
    }
}
