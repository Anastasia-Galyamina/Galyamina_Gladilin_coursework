using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Interfaсes;
using BankBusinessLogic.ViewModels;
using BankListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankListImplement.Implements
{
    public class CreditLogic : ICreditLogic
    {
        private readonly DataListSingleton source;
        public CreditLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(CreditBindingModel model)
        {
            Credit tempComponent = model.Id.HasValue ? null : new Credit
            {
                Id = 1
            };
            foreach (var component in source.Credits)
            {
                if (component.CreditName == model.CreditName && component.Id !=
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
                source.Credits.Add(CreateModel(model, tempComponent));
            }
        }
        private Credit CreateModel(CreditBindingModel model, Credit component)
        {
            component.CreditName = model.CreditName;
            component.CountMoney = model.CountMoney;
            component.DateImplement = model.DateImplement;
            component.currency = model.currency;
            return component;
        }
        private CreditViewModel CreateViewModel(Credit component)
        {
            return new CreditViewModel
            {
                Id = component.Id,
                CreditName = component.CreditName,
                DateImplement= component.DateImplement,
                CountMoney = component.CountMoney,
                currency = component.currency               
            };
        }
        public void Delete(CreditBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<CreditViewModel> Read(CreditBindingModel model)
        {
            List<CreditViewModel> result = new List<CreditViewModel>();
            foreach (var component in source.Credits)
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
