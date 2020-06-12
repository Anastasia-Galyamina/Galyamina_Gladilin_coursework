using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BankBusinessLogic.InterFaces
{
    public interface IStorageMoneyLogic
    {
        List<StorageMoneyViewModel> Read(StorageMoneyBindingModel model);
        bool RemoveMaterials(DealViewModel order);
        void CancelReservation(DealViewModel deal);
    }
}
