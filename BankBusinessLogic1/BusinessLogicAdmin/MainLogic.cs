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
        public bool CheckData(string savedPassword, string enteredPassword)
        {
            if(savedPassword == enteredPassword)
            {
                return true;
            }

            return false;
        }
    }
}
