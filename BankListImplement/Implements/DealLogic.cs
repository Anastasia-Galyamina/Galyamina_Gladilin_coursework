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
                if (product.DealName == model.DealName && product.Id != model.Id)
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
            product.DealName = model.DealName;
            product.CountCredit = model.CountCredit;
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
                    (model.DealCredit.ContainsKey(source.DealCredits[i].MoneyId))
                    {
                        // обновляем количество
                        source.DealCredits[i].Count =
                        model.DealCredit[source.DealCredits[i].MoneyId].Item2;
                        // из модели убираем эту запись, чтобы остались только не

                        model.DealCredit.Remove(source.DealCredits[i].MoneyId);
                    }
                    else
                    {
                        source.DealCredits.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.DealCredit)
            {
                source.DealCredits.Add(new DealCredit
                {
                    Id = ++maxPCId,
                    DealId = product.Id,
                    MoneyId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
        }
        private DealViewModel CreateViewModel(Deal product)
        {
            // требуется дополнительно получить список компонентов для изделия с
            Dictionary<int, (string, int)> productComponents = new Dictionary<int,
    (string, int)>();
            foreach (var pc in source.DealCredits)
            {
                if (pc.DealId == product.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Money)
                    {
                        if (pc.MoneyId == component.Id)
                        {
                            componentName = component.currency;
                            break;
                        }
                    }
                    productComponents.Add(pc.MoneyId, (componentName, pc.Count));
                }
            }
            return new DealViewModel
            {
                Id = product.Id,
                DealName = product.DealName,
                CountCredit = product.CountCredit,
                DealCredit = productComponents,
            };
        }
        public void Delete(DealBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<DealViewModel> Read(DealBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
