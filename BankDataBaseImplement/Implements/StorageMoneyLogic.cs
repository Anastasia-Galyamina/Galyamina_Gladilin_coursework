using BankBusinessLogic.BindingModels;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
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
    }
}
