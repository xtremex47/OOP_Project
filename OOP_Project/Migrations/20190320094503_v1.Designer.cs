﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OOP_Project.Classes;

namespace OOP_Project.Migrations
{
    [DbContext(typeof(OOProjectContext))]
    [Migration("20190320094503_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OOP_Project.Classes.PaymentTransactions", b =>
                {
                    b.Property<int>("PaymentTransactionsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AccumulatedAmount");

                    b.Property<double>("AmountLoaned");

                    b.Property<double>("AmountPaid");

                    b.Property<double>("Balance");

                    b.Property<long>("ContactNumber");

                    b.Property<string>("CustomerAddress");

                    b.Property<string>("CustomerName");

                    b.Property<DateTime>("DateOfTransaction");

                    b.Property<int>("TransactionId");

                    b.HasKey("PaymentTransactionsId");

                    b.HasIndex("TransactionId");

                    b.ToTable("PaymentTransactions");
                });

            modelBuilder.Entity("OOP_Project.Classes.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ActualValue");

                    b.Property<string>("Address");

                    b.Property<double>("AmountLoaned");

                    b.Property<double>("Balance");

                    b.Property<long>("ContactNumber");

                    b.Property<DateTime>("DateOfTransaction");

                    b.Property<double>("Discount");

                    b.Property<double>("InterestRate");

                    b.Property<string>("JewelryQuality");

                    b.Property<string>("JewelryType");

                    b.Property<double>("JewelryWeight");

                    b.Property<string>("Name");

                    b.Property<string>("OtherDetails");

                    b.HasKey("TransactionId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("OOP_Project.Classes.PaymentTransactions", b =>
                {
                    b.HasOne("OOP_Project.Classes.Transaction", "Transaction")
                        .WithMany("PaymentTransactionsList")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
