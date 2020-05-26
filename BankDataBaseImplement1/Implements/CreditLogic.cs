using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Interfaсes;
using BankBusinessLogic.ViewModels;
using BankDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankDataBaseImplement.Implements
{
    public class CreditLogic : ICreditLogic
    {
        public void CreateOrUpdate(CreditBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                Credit element = context.Credits.FirstOrDefault(rec =>
               rec.CreditName == model.CreditName && rec.Id != model.Id);
                if (model.Id.HasValue)
                {
                    element = context.Credits.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Credit();
                    context.Credits.Add(element);
                }
                element.CreditName = model.CreditName;
                element.Date = model.Date;
                element.Type = model.Type;                
                context.SaveChanges();
            }
        }

        public void Delete(CreditBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<CreditViewModel> Read(CreditBindingModel model)
        {
            using (var context = new BankDataBase())
            {
                return context.Credits
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new CreditViewModel
                {
                    Id = rec.Id,                    
                    CreditName = rec.CreditName,
                    Date =rec.Date,
                    Type =rec.Type
                })
                .ToList();
            }
        }
    }
}
