using BankDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDataBaseImplement
{
    public class BankDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-46FCCKM\SQLEXPRESS;
                Initial Catalog=BankTestDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Money> Money { set; get; }
        public virtual DbSet<Credit> Credits { set; get; }
        public virtual DbSet<CreditMoney> CreditMoney { set; get; }
        public virtual DbSet<Deal> Deals { set; get; }
        public virtual DbSet<Storage> Storages { set; get; }
        public virtual DbSet<StorageMoney> StorageMoney { set; get; }
    }
}
