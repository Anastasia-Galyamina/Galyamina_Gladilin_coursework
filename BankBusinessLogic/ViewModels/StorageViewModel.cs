using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BankBusinessLogic.ViewModels
{
    public class StorageViewModel
    {
        public int Id { set; get; }
        [DisplayName("Хранилище")]
        public string StorageName { set; get; }
        public Dictionary<string, int> StoragedMoney { get; set; }
    }
}
