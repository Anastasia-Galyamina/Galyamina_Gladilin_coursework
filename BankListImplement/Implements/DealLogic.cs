using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Interfaсes;
using BankBusinessLogic.ViewModels;
using BankListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankListImplement.Implements
{
    public class DealLogic : IDealLogic
    {
        private readonly DataListSingleton source;
        public DealLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(DealBindingModel model)
        {
            Deal tempProduct = model.Id.HasValue ? null : new Deal 
            { 
                Id = 1 
            };
            foreach (var product in source.Deals)
            {
                if (!model.Id.HasValue && product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempProduct == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempProduct);
            }
            else
            {
                source.Deals.Add(CreateModel(model, tempProduct));
            }
        }
        private Deal CreateModel(DealBindingModel model, Deal deal)
        {
            deal.DealName = model.DealName;
            int maxSMId = 0;
            for (int i = 0; i < source.DealCredits.Count; ++i)
            {
                if (source.DealCredits[i].Id > maxSMId)
                {
                    maxSMId = source.DealCredits[i].Id;
                }
                if (source.DealCredits[i].DealId == deal.Id)
                {
                    if (model.DealCredits.ContainsKey(source.DealCredits[i].CreditId))
                    {
                        source.DealCredits[i].Count = model.DealCredits[source.DealCredits[i].CreditId].Item2;
                        source.DealCredits[i].dateImplement = model.DealCredits[source.DealCredits[i].CreditId].Item3;
                        source.DealCredits[i].currency = model.DealCredits[source.DealCredits[i].CreditId].Item4;
                        model.DealCredits.Remove(source.DealCredits[i].CreditId);
                    }
                    else
                    {
                        source.DealCredits.RemoveAt(i--);
                    }
                }
            }
            foreach (var sm in model.DealCredits)
            {
                source.DealCredits.Add(new DealCredit
                {
                    Id = ++maxSMId,
                    DealId = deal.Id,
                    CreditId = sm.Key,
                    Count = sm.Value.Item2,
                    dateImplement = sm.Value.Item3,
                    currency = sm.Value.Item4
                });
            }
            return deal;
        }
        public void Delete(DealBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DealViewModel> Read(DealBindingModel model)
        {
            List<DealViewModel> result = new List<DealViewModel>();
            foreach (var component in source.Deals)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }
        private DealViewModel CreateViewModel(Deal deal)
        {
            Dictionary<int, (string, int, DateTime?, string)> DealCredits = new Dictionary<int,(string, int, DateTime?, string)>();
            foreach (var sm in source.DealCredits)
            {
                if (sm.DealId == deal.Id)
                {
                    string creditName = string.Empty;
                    DateTime? date = null;
                    string currency = string.Empty;
                    foreach (var credit in source.Credits)
                    {
                        if (sm.CreditId == credit.Id)
                        {
                            creditName = credit.CreditName;
                            date = credit.DateImplement;
                            currency = credit.currency;
              
                            break;
                        }
                    }
                    DealCredits.Add(sm.CreditId, (creditName, sm.Count,sm.dateImplement,sm.currency));
                }
            }
            return new DealViewModel
            {
                Id = deal.Id,
                DealName = deal.DealName,
                DealCredit = DealCredits
            };
        }
    }
}
