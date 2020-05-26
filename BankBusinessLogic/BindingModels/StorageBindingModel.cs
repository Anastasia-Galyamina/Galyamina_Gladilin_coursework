using System.Collections.Generic;

namespace BankBusinessLogic.BindingModels
{
    public class StorageBindingModel
    {
        public int? Id { set; get; }
        public string StorageName { set; get; }
        public Dictionary<int, (string, int)> StoragedMoney { get; set; }
    }
}
