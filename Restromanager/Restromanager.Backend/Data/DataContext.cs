﻿using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Domain.Entities.Measures;

namespace Restromanager.Backend.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Food> Foods { get; set;}
        public DbSet<FoodRawMaterial> FoodRawMaterials { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFood> ProductFoods { get; set; }
        public DbSet<StockRawMaterial> StockRawMaterials { get; set; }
        public DbSet<StockCommercialProduct> StockCommercialProducts { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<TypeExpense> TypeExpenses { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<TypeIncome> TypeIncomes { get; set; }
        
        public DbSet<Income> Incomes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex(x => new { x.CountryId, x.Name }).IsUnique();
            modelBuilder.Entity<City>().HasIndex(x => new { x.StateId, x.Name }).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Food>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<RawMaterial>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Unit>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<TypeExpense>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Expense>().HasIndex(e => e.TypeExpenseId);
            modelBuilder.Entity<Expense>()
                        .Property(e => e.Amount)
                        .HasPrecision(18, 2);
            modelBuilder.Entity<TypeExpense>()
                .HasMany(te => te.Expenses)
                .WithOne(e => e.TypeExpense)
                .HasForeignKey(e => e.TypeExpenseId);
            modelBuilder.Entity<TypeIncome>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Income>().HasIndex(e => e.TypeIncomeId);
            modelBuilder.Entity<Income>()
                .Property(e => e.Amount)
                .HasPrecision(18, 2);
            modelBuilder.Entity<TypeIncome>()
                .HasMany(ti => ti.Expenses)
                .WithOne(i => i.TypeIncome)
                .HasForeignKey(i => i.TypeIncomeId);
            DisableCascadingDelete(modelBuilder);
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            }
        }

    }
}
