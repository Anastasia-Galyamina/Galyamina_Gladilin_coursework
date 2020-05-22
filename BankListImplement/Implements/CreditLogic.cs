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
                    throw new Exception("Уже есть кредит с таким названием");
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
        private Credit CreateModel(CreditBindingModel model, Credit credit)
        {
            credit.CreditName = model.CreditName;
            credit.Type = model.Type;
            credit.Date = model.Date;            
            return credit;
        }
        private CreditViewModel CreateViewModel(Credit credit)
        {
            return new CreditViewModel
            {
                Id = credit.Id,
                CreditName = credit.CreditName,
                Type = credit.Type,
                Date = credit.Date
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
