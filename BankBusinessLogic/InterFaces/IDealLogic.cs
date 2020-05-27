using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.InterFaces
{
    public interface IDealLogic
    {
        List<DealViewModel> Read(DealBindingModel model);
        void CreateOrUpdate(DealBindingModel model);
        void Delete(DealBindingModel model);
    }
}
