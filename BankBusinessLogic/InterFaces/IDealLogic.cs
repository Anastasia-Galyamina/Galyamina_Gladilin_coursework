using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;


namespace BankBusinessLogic.InterFaces
{
    public interface IDealLogic
    {
        List<ReportCreditsViewModel> FormReport(DateTime dateFrom, DateTime dateTo);
        List<DealViewModel> Read(DealBindingModel model);
        void CreateOrUpdate(DealBindingModel model);
        void Delete(DealBindingModel model);
        void ReserveMoney(int id);
    }
}
