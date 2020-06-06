﻿// <auto-generated />
using System;
using BankDataBaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankDataBaseImplement.Migrations
{
    [DbContext(typeof(BankDataBase))]
    [Migration("20200601232423_mgFinal")]
    partial class mgFinal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankDataBaseImplement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientFIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.Credit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreditName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Term")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.CreditMoney", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("CreditId")
                        .HasColumnType("int");

                    b.Property<int>("MoneyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreditId");

                    b.HasIndex("MoneyId");

                    b.ToTable("CreditMoney");
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.Deal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientFIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("DealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.DealCredits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreditId")
                        .HasColumnType("int");

                    b.Property<int>("DealId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("dateImplement")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreditId");

                    b.HasIndex("DealId");

                    b.ToTable("DealCredits");
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.Money", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Money");
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.ResesvedMoney", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("DealId")
                        .HasColumnType("int");

                    b.Property<string>("DealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("countMoney")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ResesvedMoney");
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StorageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.StorageMoney", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("MoneyId")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MoneyId");

                    b.HasIndex("StorageId");

                    b.ToTable("StorageMoney");
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.CreditMoney", b =>
                {
                    b.HasOne("BankDataBaseImplement.Models.Credit", "Credit")
                        .WithMany("CreditMoney")
                        .HasForeignKey("CreditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankDataBaseImplement.Models.Money", "Money")
                        .WithMany("CreditMoney")
                        .HasForeignKey("MoneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.Deal", b =>
                {
                    b.HasOne("BankDataBaseImplement.Models.Client", null)
                        .WithMany("Deals")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.DealCredits", b =>
                {
                    b.HasOne("BankDataBaseImplement.Models.Credit", "Credit")
                        .WithMany("DealCredits")
                        .HasForeignKey("CreditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankDataBaseImplement.Models.Deal", "Deal")
                        .WithMany("DealCredits")
                        .HasForeignKey("DealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.ResesvedMoney", b =>
                {
                    b.HasOne("BankDataBaseImplement.Models.Client", "Client")
                        .WithMany("ResesvedMoney")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("BankDataBaseImplement.Models.StorageMoney", b =>
                {
                    b.HasOne("BankDataBaseImplement.Models.Money", "Money")
                        .WithMany("StorageMoney")
                        .HasForeignKey("MoneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankDataBaseImplement.Models.Storage", "Storage")
                        .WithMany("StorageMoney")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
