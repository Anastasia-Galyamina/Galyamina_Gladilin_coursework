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
                Deal deal;
                if (model.Id.HasValue)
                {
                    deal = context.Deals.ToList().FirstOrDefault(rec => rec.Id == model.Id);
                    if (deal == null)
                        throw new Exception("Элемент не найден");
                }
                else
                {
                    deal = new Deal();
                    context.Deals.Add(deal);
                }
                deal.CreditId = model.CreditId;
                deal.Count = model.Count;
                deal.DateCreate = model.DateCreate;
                deal.DateImplement = model.DateImplement;
                deal.Status = model.Status;
                deal.Sum = model.Sum;
                context.SaveChanges();
            }
        }

        public void Delete(DealBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                Deal deal = context.Deals.FirstOrDefault(rec => rec.Id == model.Id);
                if (deal != null)
                {
                    context.Deals.Remove(deal);
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
                context.SaveChanges();
            }
        }

        public List<DealViewModel> Read(DealBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.Deals.Where(rec => model == null || rec.Id == model.Id)
                .Include(ord => ord.Credit)
                .Select(rec => new DealViewModel()
                {
                    Id = rec.Id,
                    CreditId = rec.CreditId,
                    CreditName = rec.Credit.CreditName,
                    Count = rec.Count,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    Status = rec.Status,
                    Sum = rec.Sum
                }).ToList();
            }
        }
    }
}
