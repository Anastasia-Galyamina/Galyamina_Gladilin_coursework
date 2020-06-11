using BankBusinessLogic.BindingModels;
using BankBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BankBusinessLogic.InterFaces
{
    public interface IRequestLogic
    {
        List<RequestViewModel> ReadRequests(RequestBindingModel model);
        void Save(RequestViewModel model);
        RequestViewModel GetRequest(RequestBindingModel model);
        Dictionary<string, int> Read();
        int GetId();
        void SendMessage(RequestBindingModel model);
        void DocRequest(RequestBindingModel model);
        void ExelRequest(RequestBindingModel model);
    }
}
