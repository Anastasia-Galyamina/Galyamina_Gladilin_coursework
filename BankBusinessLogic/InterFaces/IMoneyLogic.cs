using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.InterFaces
{
    public interface IMoneyLogic
    {
        List<MoneyViewModel> Read(MoneyBindingModel model);
        void CreateOrUpdate(MoneyBindingModel model);
        void Delete(MoneyBindingModel model);
    }
}
