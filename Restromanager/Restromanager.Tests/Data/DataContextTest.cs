using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Domain.Entities.Measures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Restromanager.Tests.Data
{
    [TestClass]
    public class DataContextTest
    {
        private DbContextOptions<DataContext> _options;

        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                        .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDatabase;Trusted_Connection=True;MultipleActiveResultSets=true")
                        .Options;

            using (var context = new DataContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        [TestMethod]
        public void CanInsertCountryIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var country = new Country { Name = "Test Country" };
                context.Countries.Add(country);
                context.SaveChanges();

                Assert.AreEqual(1, context.Countries.Count());
                Assert.AreEqual("Test Country", context.Countries.Single().Name);
            }
        }

        [TestMethod]
        public void CanInsertCityIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var country = new Country { Name = "Test Country" };
                context.Countries.Add(country);
                context.SaveChanges();

                var state = new State { Name = "Test State", Country = country };
                context.States.Add(state);
                context.SaveChanges();

                var city = new City { Name = "Test City", State = state };
                context.Cities.Add(city);
                context.SaveChanges();

                Assert.AreEqual(1, context.Cities.Count());
                Assert.AreEqual("Test City", context.Cities.Single().Name);
            }
        }

        [TestMethod]
        public void CanInsertCategoryIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var category = new Category { Name = "Test Category" };
                context.Categories.Add(category);
                context.SaveChanges();

                Assert.AreEqual(1, context.Categories.Count());
                Assert.AreEqual("Test Category", context.Categories.Single().Name);
            }
        }

        [TestMethod]
        public void CanInsertFoodIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var food = new Food { Name = "Test Food" };
                context.Foods.Add(food);
                context.SaveChanges();

                Assert.AreEqual(1, context.Foods.Count());
                Assert.AreEqual("Test Food", context.Foods.Single().Name);
            }
        }


        [TestMethod]
        public void CanInsertRawMaterialIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var rawMaterial = new RawMaterial { Name = "Test RawMaterial" };
                context.RawMaterials.Add(rawMaterial);
                context.SaveChanges();

                Assert.AreEqual(1, context.RawMaterials.Count());
                Assert.AreEqual("Test RawMaterial", context.RawMaterials.Single().Name);
            }
        }

        [TestMethod]
        public void CanInsertTypeExpenseIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var typeExpense = new TypeExpense { Name = "Test TypeExpense" };
                context.TypeExpenses.Add(typeExpense);
                context.SaveChanges();

                Assert.AreEqual(1, context.TypeExpenses.Count());
                Assert.AreEqual("Test TypeExpense", context.TypeExpenses.Single().Name);
            }
        }


        [TestMethod]
        public void CanInsertTypeIncomeIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var typeIncome = new TypeIncome { Name = "Test TypeIncome" };
                context.TypeIncomes.Add(typeIncome);
                context.SaveChanges();

                Assert.AreEqual(1, context.TypeIncomes.Count());
                Assert.AreEqual("Test TypeIncome", context.TypeIncomes.Single().Name);
            }
        }

        [TestMethod]
        public void CanInsertTypeReportIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var typeReport = new TypeReport { Name = "Test TypeReport" };
                context.TypesReport.Add(typeReport);
                context.SaveChanges();

                Assert.AreEqual(1, context.TypesReport.Count());
                Assert.AreEqual("Test TypeReport", context.TypesReport.Single().Name);
            }
        }

        [TestMethod]
        public void CanInsertUserReportIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var userReport = new UserReport { Name = "Test UserReport" };
                context.UserReports.Add(userReport);
                context.SaveChanges();

                Assert.AreEqual(1, context.UserReports.Count());
                Assert.AreEqual("Test UserReport", context.UserReports.Single().Name);
            }
        }

        [TestMethod]
        public void CanInsertTableIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var table = new Table { Name = "Test Table" };
                context.Tables.Add(table);
                context.SaveChanges();

                Assert.AreEqual(1, context.Tables.Count());
                Assert.AreEqual("Test Table", context.Tables.Single().Name);
            }
        }

        [TestMethod]
        public void ModelBuilder_ConfiguresIndexesAndRelationships()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var model = context.Model;
                var countryEntity = model.FindEntityType(typeof(Country));
                var stateEntity = model.FindEntityType(typeof(State));
                var cityEntity = model.FindEntityType(typeof(City));
                var categoryEntity = model.FindEntityType(typeof(Category));
                var foodEntity = model.FindEntityType(typeof(Food));
                var productEntity = model.FindEntityType(typeof(Product));
                var rawMaterialEntity = model.FindEntityType(typeof(RawMaterial));
                var unitEntity = model.FindEntityType(typeof(Unit));
                var typeExpenseEntity = model.FindEntityType(typeof(TypeExpense));
                var expenseEntity = model.FindEntityType(typeof(Expense));
                var typeIncomeEntity = model.FindEntityType(typeof(TypeIncome));
                var incomeEntity = model.FindEntityType(typeof(Income));
                var reportEntity = model.FindEntityType(typeof(Report));
                var typeReportEntity = model.FindEntityType(typeof(TypeReport));
                var userReportEntity = model.FindEntityType(typeof(UserReport));
                var favoriteTasteEntity = model.FindEntityType(typeof(FavoriteTaste));
                var orderEntity = model.FindEntityType(typeof(Order));
                var orderDetailEntity = model.FindEntityType(typeof(OrderDetail));
                var tableEntity = model.FindEntityType(typeof(Table));

                Assert.IsTrue(countryEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(stateEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(cityEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(categoryEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(foodEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(productEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(rawMaterialEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(unitEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(typeExpenseEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(typeIncomeEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(reportEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(typeReportEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(userReportEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(favoriteTasteEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "UserID" && i.IsUnique)));
                Assert.IsTrue(tableEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));

                var expenseTypeForeignKey = expenseEntity!.GetForeignKeys().SingleOrDefault(fk => fk.PrincipalEntityType.ClrType == typeof(TypeExpense));
                Assert.IsNotNull(expenseTypeForeignKey);
                Assert.AreEqual(DeleteBehavior.Restrict, expenseTypeForeignKey.DeleteBehavior);

                var incomeTypeForeignKey = incomeEntity!.GetForeignKeys().SingleOrDefault(fk => fk.PrincipalEntityType.ClrType == typeof(TypeIncome));
                Assert.IsNotNull(incomeTypeForeignKey);
                Assert.AreEqual(DeleteBehavior.Restrict, incomeTypeForeignKey.DeleteBehavior);

                var productCategoryForeignKey = model.FindEntityType(typeof(ProductCategory)).GetForeignKeys().SingleOrDefault(fk => fk.PrincipalEntityType.ClrType == typeof(Product));
                Assert.IsNotNull(productCategoryForeignKey);
                Assert.AreEqual(DeleteBehavior.Cascade, productCategoryForeignKey.DeleteBehavior);

                var foodRawMaterialForeignKey = model.FindEntityType(typeof(FoodRawMaterial)).GetForeignKeys().SingleOrDefault(fk => fk.PrincipalEntityType.ClrType == typeof(Food));
                Assert.IsNotNull(foodRawMaterialForeignKey);
                Assert.AreEqual(DeleteBehavior.Cascade, foodRawMaterialForeignKey.DeleteBehavior);

                var productFoodForeignKey = model.FindEntityType(typeof(ProductFood)).GetForeignKeys().SingleOrDefault(fk => fk.PrincipalEntityType.ClrType == typeof(Product));
                Assert.IsNotNull(productFoodForeignKey);
                Assert.AreEqual(DeleteBehavior.Cascade, productFoodForeignKey.DeleteBehavior);
            }
        }
    }
}
