using BankBusinessLogic.BindingModels;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankDataBaseImplement.Implements
{
    public class StorageMoneyLogic : IStorageMoneyLogic
    {
        public List<StorageMoneyViewModel> Read(StorageMoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.StorageMoney
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new StorageMoneyViewModel
                {
                    Id = rec.Id,
                    Currency = rec.Money.Currency,
                    Count = rec.Count,
                    Reserved = rec.Reserved
                })
                .ToList();
            }
        }
        public bool RemoveMaterials(DealViewModel deal)
        {
            using (var context = new BankDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var dealCredit in deal.DealCredits)
                        {
                            var storageMoney = context.StorageMoney.ToList();
                            int dealCount = 0;
                            int value;
                            int.TryParse(string.Join("", dealCredit.Value.Item1.Where(c => char.IsDigit(c))), out value);
                            dealCount += value;
                            var moneyCount = dealCount;
                            foreach (var sm in storageMoney)
                            {
                                if (sm.Count >= moneyCount)
                                {
                                    sm.Count -= moneyCount;
                                    moneyCount = 0;
                                    context.SaveChanges();
                                    break;
                                }
                            }
                            if (moneyCount > 0)
                                throw new Exception("Не хватает денег в хранилище!");
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

    }
}
