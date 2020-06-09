using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.InterFaces
{
    public interface IReservMoney
    {
        List<ReservedMoneyViewModel> Read(ReservedMoneyBindingModel model);
        void CreateOrUpdate(ReservedMoneyBindingModel model);
        void Delete(ReservedMoneyBindingModel model);
    }
}
