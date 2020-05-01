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
        private DataListSingleton()
        {
            Credits = new List<Credit>();
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
