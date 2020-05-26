using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
using BankDataBaseImplement.Implements;
using FurnitureShopView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace BankAdminView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IMoneyLogic, MoneyLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDealLogic, DealLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICreditLogic, CreditLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageLogic, StorageLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
