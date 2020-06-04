using BankBusinessLogic.BindingModels;
using BankBusinessLogic.HelperModelsClient;
using BankBusinessLogic.InterFaces;
using BankBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankBusinessLogic.BusnessLogic
{
    public class ReportLogic
    {
        private readonly IDealLogic dealLogic;
        private readonly ICreditLogic creditLogic;

        public ReportLogic(IDealLogic dealLogic, ICreditLogic creditLogic)
        {
            this.dealLogic = dealLogic;
            this.creditLogic = creditLogic;
        }
        public List<ReportDealViewModel> GetDeals(ReportBindingModel model)
        {
            var list = new List<ReportDealViewModel>();
            foreach (var DealId in model.DealsId)
            {
                var credits = creditLogic.Read(null);
                var deals = dealLogic.Read(new DealBindingModel()
                {
                    Id = DealId
                });
                foreach (var credit in credits)
                {
                    foreach (var deal in deals)
                    {
                        if (deal.DealCredits.ContainsKey(credit.Id))
                        {
                            var record = new ReportDealViewModel
                            {
                                CreditName = deal.DealCredits[credit.Id].Item1,
                                DealName = deal.DealName,
                                date = deal.DealCredits[credit.Id].Item2
                            };
                            list.Add(record);
                        }
                    }
                }
            }
            return list;
        }
        public void DocCreditDeal(ReportBindingModel model)
        {
            SaveToWordClient.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Сделки",
                Deals = GetDeals(model)
            });
        }
    }
}
