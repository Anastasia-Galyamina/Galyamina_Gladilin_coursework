using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BankBusinessLogic.InterFaces
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);

        void CreateOrUpdate(ClientBindingModel model);

        void Delete(ClientBindingModel model);
    }
}
