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
    public class StorageLogic : IStorageLogic
    {
        public void AddMaterialToStorage(StorageAddMoneyBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                var storageMaterial = context.StorageMoney
                    .FirstOrDefault(sm => sm.MoneyId == model.MoneyId && sm.StorageId == model.StorageId);
                if (storageMaterial != null)
                    storageMaterial.Count += model.MoneyCount;
                else
                    context.StorageMoney.Add(new StorageMoney()
                    {
                        MoneyId = model.MoneyId,
                        StorageId = model.StorageId,
                        Count = model.MoneyCount
                    });
                context.SaveChanges();
            }
        }

        public void CreateOrUpdate(StorageBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Storage();
                    context.Storages.Add(element);
                }
                element.StorageName = model.StorageName;
                context.SaveChanges();
            }
        }

        public void Delete(StorageBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                context.StorageMoney.RemoveRange(context.StorageMoney.Where(rec => rec.StorageId == model.Id));
                Storage element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Storages.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<StorageViewModel> Read(StorageBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.Storages.Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new StorageViewModel
                {
                    Id = rec.Id,
                    StorageName = rec.StorageName,
                    StoragedMoney = context.StorageMoney.Include(recSM => recSM.Money)
                                                           .Where(recSM => recSM.StorageId == rec.Id)
                                                           .ToDictionary(recSM => recSM.Money.Currency, recSM => recSM.Count)
                }).ToList();
            }
        }

        public bool RemoveMaterials(DealViewModel order)
        {
            throw new NotImplementedException();
        }

        //public bool RemoveMaterials(DealViewModel order)
        //{
        //    using (var context = new BankDataBase())
        //    {
        //        using (var transaction = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //               / var dressMaterials = context.CreditMoney.Where(dm => dm.CreditId == order.CreditId).ToList();
        //                var storageMaterials = context.StorageMoney.ToList();
        //                foreach (var material in dressMaterials)
        //                {
        //                    /////////////////dodelat!!!!
        //                    var materialCount = 0;
        //                    foreach (var sm in storageMaterials)
        //                    {
        //                        if (sm.MoneyId == material.MoneyId && sm.Count >= materialCount)
        //                        {
        //                            sm.Count -= materialCount;
        //                            materialCount = 0;
        //                            context.SaveChanges();
        //                            break;
        //                        }
        //                        else if (sm.MoneyId == material.MoneyId && sm.Count < materialCount)
        //                        {
        //                            materialCount -= sm.Count;
        //                            sm.Count = 0;
        //                            context.SaveChanges();
        //                        }
        //                    }
        //                    if (materialCount > 0)
        //                        throw new Exception("Не хватает материалов на складах!");
        //                }
        //                transaction.Commit();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
    }
}
