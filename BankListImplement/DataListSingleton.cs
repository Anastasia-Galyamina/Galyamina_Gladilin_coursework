using BankListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Credit> Credits { get; set; }
        public List<Money> Money { get; set; }
        public List<Deal> Deals { get; set; }
        public List<DealCredit> DealCredits { get; set; }
        private DataListSingleton()
        {
            Credits = new List<Credit>();
            Money = new List<Money>();
            Deals = new List<Deal>();
            DealCredits = new List<DealCredit>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
