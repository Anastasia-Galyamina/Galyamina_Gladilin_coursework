using System.Collections.Generic;


namespace BankBusinessLogic.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public Dictionary<int, (string, int)> Money { get; set; }
    }
}
