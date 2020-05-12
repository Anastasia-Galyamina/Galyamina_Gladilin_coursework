﻿using BankDataBaseImplement.Models;
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
                optionsBuilder.UseSqlServer(@"Data Source=WIN-O5P3KVSKC8M\SQLEXPRESS;Initial Catalog=BankDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Money> Money { set; get; }
        public virtual DbSet<Credit> Credits { set; get; }
        public virtual DbSet<DealCredit> DealCredits { set; get; }
        public virtual DbSet<Deal> Deals { set; get; }
    }
}
