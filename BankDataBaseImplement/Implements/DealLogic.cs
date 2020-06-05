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
    public class DealLogic : IDealLogic
    {
        public void CreateOrUpdate(DealBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Deal element = context.Deals.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть сделка с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Deals.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Deal();
                            context.Deals.Add(element);
                        }
                        element.DealName = model.DealName;
                        element.ClientId = model.ClientId == 0 ? element.ClientId : model.ClientId;
                        element.ClientFIO = model.ClientFIO;
                        element.Status = model.Status;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.DealCredits.Where(rec => rec.DealId == model.Id.Value).ToList();
                            context.DealCredits.RemoveRange(productComponents.Where(rec => !model.DealCredits.ContainsKey(rec.CreditId)).ToList());
                            context.SaveChanges();
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.dateImplement = model.DealCredits[updateComponent.CreditId].Item2;
                                model.DealCredits.Remove(updateComponent.CreditId);
                            }
                            context.SaveChanges();
                        }
                        foreach (var pc in model.DealCredits)
                        {
                            context.DealCredits.Add(new DealCredits
                            {
                                DealId = element.Id,
                                CreditId = pc.Key,
                                dateImplement = pc.Value.Item2
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

        public void Delete(DealBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.DealCredits.RemoveRange(context.DealCredits.Where(rec => rec.DealId == model.Id));
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

        public List<DealViewModel> Read(DealBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.Deals.Where(rec => model == null || (rec.Id == model.Id && model.Id.HasValue)||
                (model.ClientId.HasValue && rec.ClientId == model.ClientId))
                .ToList()
                .Select(rec => new DealViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    DealName = rec.DealName,
                    ClientFIO = rec.ClientFIO,
                    Status= rec.Status,
                    DealCredits = context.DealCredits.Include(recPC => recPC.Credit)
                                                           .Where(recPC => recPC.DealId == rec.Id)
                                                           .ToDictionary(recPC => recPC.CreditId, recPC => (recPC.Credit?.CreditName, recPC.dateImplement))
                }).ToList();
            }
        }
    }
}
