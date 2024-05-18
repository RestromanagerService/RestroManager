using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Domain.Entities.Measures;

namespace Restromanager.Backend.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodRawMaterial> FoodRawMaterials { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductFood> ProductFoods { get; set; }
        public DbSet<StockRawMaterial> StockRawMaterials { get; set; }
        public DbSet<StockCommercialProduct> StockCommercialProducts { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<TypeExpense> TypeExpenses { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TypeIncome> TypeIncomes { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<TypeReport> TypesReport { get; set; }
        public DbSet<UserReport> UserReports { get; set; }



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
            modelBuilder.Entity<Report>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Report>().Property(r => r.LabelValue).HasPrecision(18, 2);
            modelBuilder.Entity<TypeReport>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<UserReport>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<ProductCategory>().HasIndex(x => new { x.ProductId, x.CategoryId }).IsUnique();
            modelBuilder.Entity<FoodRawMaterial>().HasIndex(x => new { x.FoodId, x.RawMaterialId }).IsUnique();
            modelBuilder.Entity<ProductFood>().HasIndex(x => new { x.ProductId, x.FoodId }).IsUnique();
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FoodRawMaterial>()
                .HasOne(frm => frm.Food)
                .WithMany(f => f.FoodRawMaterials)
                .HasForeignKey(frm => frm.FoodId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductFood>()
                .HasOne(pf => pf.Product)
                .WithMany(p => p.ProductFoods)
                .HasForeignKey(pf => pf.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            DisableCascadingDelete(modelBuilder);
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                if (!(relationship.DeclaringEntityType.ClrType.Name == "ProductCategory" ||
                      relationship.DeclaringEntityType.ClrType.Name == "FoodRawMaterial" ||
                      relationship.DeclaringEntityType.ClrType.Name == "ProductFood"))
                {
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }

    }
}
