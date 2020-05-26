using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Interfaсes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BusinessLogic
{
    public class MainLogic
    {
        private readonly IDealLogic dealLogic;
        public MainLogic(IDealLogic dealLogic)
        {
            this.dealLogic = dealLogic;
        }
        public void CreateOrder(CreateDealBindingModel model)
        {
            dealLogic.CreateOrUpdate(new DealBindingModel
            {
             
            });;
        }
    }
}
