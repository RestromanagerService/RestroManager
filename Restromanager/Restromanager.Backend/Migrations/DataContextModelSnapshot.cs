﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restromanager.Backend.Data;

#nullable disable

namespace Restromanager.Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId", "Name")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeExpenseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeExpenseId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("ProductionCost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.FoodRawMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasMaxLength(255)
                        .HasColumnType("float");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("RawMaterialId")
                        .HasColumnType("int");

                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("RawMaterialId");

                    b.HasIndex("UnitsId");

                    b.ToTable("FoodRawMaterials");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeIncomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeIncomeId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Measures.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("ProductionCost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.ProductFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasMaxLength(255)
                        .HasColumnType("float");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitsId");

                    b.ToTable("ProductFoods");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.RawMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("RawMaterials");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId", "Name")
                        .IsUnique();

                    b.ToTable("States");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.StockCommercialProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Aumount")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<double>("UnitCost")
                        .HasColumnType("float");

                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitsId");

                    b.ToTable("StockCommercialProducts");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.StockRawMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Aumount")
                        .HasColumnType("float");

                    b.Property<int>("RawMaterialId")
                        .HasColumnType("int");

                    b.Property<double>("UnitCost")
                        .HasColumnType("float");

                    b.Property<int>("UnitsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RawMaterialId");

                    b.HasIndex("UnitsId");

                    b.ToTable("StockRawMaterials");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.TypeExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TypeExpenses");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.TypeIncome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TypeIncomes");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Category", b =>
                {
                    b.HasOne("Restromanager.Backend.Domain.Entities.Product", null)
                        .WithMany("Categories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.City", b =>
                {
                    b.HasOne("Restromanager.Backend.Domain.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Expense", b =>
                {
                    b.HasOne("Restromanager.Backend.Domain.Entities.TypeExpense", "TypeExpense")
                        .WithMany("Expenses")
                        .HasForeignKey("TypeExpenseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TypeExpense");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.FoodRawMaterial", b =>
                {
                    b.HasOne("Restromanager.Backend.Domain.Entities.Food", "Food")
                        .WithMany("FoodRawMaterials")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Restromanager.Backend.Domain.Entities.RawMaterial", "RawMaterial")
                        .WithMany()
                        .HasForeignKey("RawMaterialId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Restromanager.Backend.Domain.Entities.Measures.Unit", "Units")
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("RawMaterial");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Income", b =>
                {
                    b.HasOne("Restromanager.Backend.Domain.Entities.TypeIncome", "TypeIncome")
                        .WithMany("Expenses")
                        .HasForeignKey("TypeIncomeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TypeIncome");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.ProductFood", b =>
                {
                    b.HasOne("Restromanager.Backend.Domain.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Restromanager.Backend.Domain.Entities.Product", "Product")
                        .WithMany("ProductFoods")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Restromanager.Backend.Domain.Entities.Measures.Unit", "Units")
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Product");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.State", b =>
                {
                    b.HasOne("Restromanager.Backend.Domain.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.StockCommercialProduct", b =>
                {
                    b.HasOne("Restromanager.Backend.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Restromanager.Backend.Domain.Entities.Measures.Unit", "Units")
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.StockRawMaterial", b =>
                {
                    b.HasOne("Restromanager.Backend.Domain.Entities.RawMaterial", "RawMaterial")
                        .WithMany()
                        .HasForeignKey("RawMaterialId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Restromanager.Backend.Domain.Entities.Measures.Unit", "Units")
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RawMaterial");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Food", b =>
                {
                    b.Navigation("FoodRawMaterials");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.Product", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("ProductFoods");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.TypeExpense", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Restromanager.Backend.Domain.Entities.TypeIncome", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
