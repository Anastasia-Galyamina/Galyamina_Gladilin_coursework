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
            Deal tempProduct = model.Id.HasValue ? null : new Deal { Id = 1 };
            foreach (var product in source.Deals)
            {
                if (product.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
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
        private Deal CreateModel(DealBindingModel model, Deal product)
        {
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxPCId = 0;
            for (int i = 0; i < source.DealCredits.Count; ++i)
            {
                if (source.DealCredits[i].Id > maxPCId)
                {
                    maxPCId = source.DealCredits[i].Id;
                }
                if (source.DealCredits[i].DealId == product.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (model.DealCredits.ContainsKey(source.DealCredits[i].CreditId))
                    {
                        // обновляем количество
                        source.DealCredits[i].Count =
                        model.DealCredits[source.DealCredits[i].CreditId].Item2;
                        // из модели убираем эту запись, чтобы остались только не
                        model.DealCredits.Remove(source.DealCredits[i].CreditId);
                    }
                    else
                    {
                        source.DealCredits.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.DealCredits)
            {
                source.DealCredits.Add(new DealCredit
                {
                    Id = ++maxPCId,
                    DealId = product.Id,
                    CreditId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
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
        private DealViewModel CreateViewModel(Deal product)
        {
            // требуется дополнительно получить список компонентов для изделия с
            Dictionary<int, (string, int, DateTime?, string)> productComponents = new Dictionary<int,(string, int, DateTime?, string)>();
            foreach (var pc in source.DealCredits)
            {
                if (pc.DealId == product.Id)
                {
                    string componentName = string.Empty;
                    DateTime? dateTime = null;
                    string currency = string.Empty;
                    foreach (var component in source.Credits)
                    {
                        if (pc.CreditId == component.Id)
                        {
                            componentName = component.CreditName;
                            dateTime = component.DateImplement;
                            currency = component.currency;
                            break;
                        }
                    }
                    productComponents.Add(pc.CreditId, (componentName, pc.Count,dateTime,currency));
                }
            }
            return new DealViewModel
            {
                Id = product.Id,
                DealCredit = productComponents,
            };
        }
    }
}
