using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.InterFaces
{
    public interface IDealLogic
    {
        List<KeyValuePair<int, (string, string, string, string, System.DateTime?, string, decimal)>> FormReport();
        List<DealViewModel> Read(DealBindingModel model);
        void CreateOrUpdate(DealBindingModel model);
        void Delete(DealBindingModel model);
        void ReserveMoney(int id);
    }
}
