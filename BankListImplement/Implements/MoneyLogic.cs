using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Interfaсes;
using BankBusinessLogic.ViewModels;
using BankListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankListImplement.Implements
{
    public class MoneyLogic : IMoneyLogic
    {
        private readonly DataListSingleton source;
        public MoneyLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(MoneyBindingModel model)
        {
            Money tempComponent = model.Id.HasValue ? null : new Money
            {
                Id = 1
            };
            foreach (var component in source.Money)
            {
                if (component.currency == model.currency && component.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (!model.Id.HasValue && component.Id >= tempComponent.Id)
                {
                    tempComponent.Id = component.Id + 1;
                }
                else if (model.Id.HasValue && component.Id == model.Id)
                {
                    tempComponent = component;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempComponent == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempComponent);
            }
            else
            {
                source.Money.Add(CreateModel(model, tempComponent));
            }
        }
        private Money CreateModel(MoneyBindingModel model, Money component)
        {
            component.currency = model.currency;
            return component;
        }
        private MoneyViewModel CreateViewModel(Money component)
        {
            return new MoneyViewModel
            {
                Id = component.Id,
                currency = component.currency
            };
        }

        public void Delete(MoneyBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<MoneyViewModel> Read(MoneyBindingModel model)
        {
            List<MoneyViewModel> result = new List<MoneyViewModel>();
            foreach (var component in source.Money)
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
    }
}
