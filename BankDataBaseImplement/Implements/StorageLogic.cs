using BankBusinessLogic.BindingModels;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using BankDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BankDataBaseImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {        
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
               // context.StorageMoney.RemoveRange(context.StorageMoney.Where(rec => rec.StorageId == model.Id));
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
                                                           // .Where(recSM => recSM.StorageId == rec.Id)
                                                           .ToDictionary(recSM => recSM.Money.Currency, recSM => recSM.Count)
                }).ToList();
            }
        }       
        private const string urlPattern = "http://rate-exchange-1.appspot.com/currency?from={0}&to={1}";
        public decimal CurrencyConversion(decimal amount, string fromCurrency, string toCurrency)
        {
            string url = string.Format(urlPattern, fromCurrency, toCurrency);

            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                Newtonsoft.Json.Linq.JToken token = Newtonsoft.Json.Linq.JObject.Parse(json);
                decimal exchangeRate = (decimal)token.SelectToken("rate");

                return (amount * exchangeRate);
            }
        }
        public bool RemoveMaterials(DealViewModel deal)
        {
            //Eur
            decimal Rate = CurrencyConversion(1, "USD", "RUB");
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
                                if ( sm.Count >= moneyCount)
                                {
                                    sm.Count -= moneyCount;
                                    moneyCount = 0;
                                    context.SaveChanges();
                                    break;
                                }
                                else if (sm.MoneyId == 2 && sm.Count < moneyCount)
                                {
                                    moneyCount -= sm.Count* Convert.ToInt32(Rate);
                                    sm.Count = 0;
                                    context.SaveChanges();
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
