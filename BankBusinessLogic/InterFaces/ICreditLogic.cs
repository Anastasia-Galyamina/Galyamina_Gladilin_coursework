using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.InterFaces
{
    public interface ICreditLogic
    {
        List<CreditViewModel> Read(CreditBindingModel model);
        void CreateOrUpdate(CreditBindingModel model);
        void Delete(CreditBindingModel model);
    }
}
