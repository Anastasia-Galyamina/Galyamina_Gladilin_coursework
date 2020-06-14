using BankBusinessLogic.BusnessLogic;
using BankBusinessLogic.InterFaces;
using BankDataBaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace BankAdminView
{
    static class Program
    {
        public static bool isLogged = false;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var formEnter = new FormEnter();
            formEnter.ShowDialog();
            if (isLogged)
            {
            Application.Run(container.Resolve<FormMain>());
            }
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
            currentContainer.RegisterType<BackUpAbstractLogic, BackUpLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageMoneyLogic, StorageMoneyLogic>(new HierarchicalLifetimeManager());           
            currentContainer.RegisterType<IRequestLogic, RequestLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
