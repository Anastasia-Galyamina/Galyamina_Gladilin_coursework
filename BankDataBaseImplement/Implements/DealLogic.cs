using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Interfaсes;
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
                        Deal element = context.Deals.FirstOrDefault(rec =>
                       rec.DealName == model.DealName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Deals.FirstOrDefault(rec => rec.Id ==
                           model.Id);
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
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.DealCredits.Where(rec
                           => rec.DealId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.DealCredits.RemoveRange(productComponents.Where(rec =>
                            !model.DealCredits.ContainsKey(rec.CreditId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count =
                               model.DealCredits[updateComponent.CreditId].Item2;
                                updateComponent.dateImplement =
                              model.DealCredits[updateComponent.CreditId].Item3;
                                updateComponent.currency =
                              model.DealCredits[updateComponent.CreditId].Item4;

                                model.DealCredits.Remove(updateComponent.CreditId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.DealCredits)
                        {
                            context.DealCredits.Add(new DealCredit
                            {
                                DealId = element.Id,
                                CreditId = pc.Key,
                                Count = pc.Value.Item2,
                                dateImplement =pc.Value.Item3,
                                currency = pc.Value.Item4
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
            throw new NotImplementedException();
        }

        public List<DealViewModel> Read(DealBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.Deals
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new DealViewModel
               {
                   Id = rec.Id,
                   DealName = rec.DealName,
                   DealCredit = context.DealCredits
                .Include(recPC => recPC.Credit)
               .Where(recPC => recPC.DealId == rec.Id)
               .ToDictionary(recPC => recPC.CreditId, recPC =>
                (recPC.Credit?.CreditName, recPC.Count,recPC.dateImplement,recPC.currency))
               })
               .ToList();
            }
        }
    }
}
