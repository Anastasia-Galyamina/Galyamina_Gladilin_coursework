using System;
using System.Collections.Generic;
using System.Text;

namespace BankBusinessLogic.BindingModels
{
    public class StorageAddMoneyBindingModel
    {
        public int StorageId { set; get; }
        public int MoneyId { set; get; }
        public int MoneyCount { set; get; }
    }
}
