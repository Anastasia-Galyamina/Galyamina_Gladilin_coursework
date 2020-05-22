using BankBusinessLogic.BindingModels;
using BankBusinessLogic.Interfaсes;

namespace BankBusinessLogic.BusinessLogicAdmin
{
    public class MainLogic
    {
        private readonly ICreditLogic logic;
        public MainLogic(ICreditLogic logic)
        {
            this.logic = logic;
        }
        public void AddCredit(CreditBindingModel model)
        {
            logic.CreateOrUpdate(new CreditBindingModel
            {
                Id = model.Id,
                CreditName = model.CreditName,
                Date = model.Date,
                Type = model.Type
            }); ;
        }
    }
}
