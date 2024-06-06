using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;

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
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;
        }

        [TestMethod]
        public void CanInsertCityIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                var city = new City { Name = "Test City" };
                context.Cities.Add(city);
                context.SaveChanges();

                Assert.AreEqual(1, context.Cities.Count());
                Assert.AreEqual("Test City", context.Cities.Single().Name);
            }
        }

        [TestMethod]
        public void CanInsertCountryIntoDatabase()
        {
            using (var context = new DataContext(_options))
            {
                var country = new Country { Name = "Test Country" };
                context.Countries.Add(country);
                context.SaveChanges();

                Assert.AreEqual(1, context.Countries.Count());
                Assert.AreEqual("Test Country", context.Countries.Single().Name);
            }
        }

        [TestMethod]
        public void ModelBuilder_ConfiguresIndexesAndRelationships()
        {
            using (var context = new DataContext(_options))
            {
                var model = context.Model;
                var countryEntity = model.FindEntityType(typeof(Country));
                var stateEntity = model.FindEntityType(typeof(State));
                var cityEntity = model.FindEntityType(typeof(City));

                Assert.IsTrue(countryEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(stateEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));
                Assert.IsTrue(cityEntity!.GetIndexes().Any(i => i.Properties.Any(p => p.Name == "Name" && i.IsUnique)));

                // Verify relationships
                var expenseEntity = model.FindEntityType(typeof(Expense));
                var expenseTypeForeignKey = expenseEntity!.GetForeignKeys().SingleOrDefault(fk => fk.PrincipalEntityType.ClrType == typeof(TypeExpense));
                Assert.IsNotNull(expenseTypeForeignKey);
                Assert.AreEqual(DeleteBehavior.Restrict, expenseTypeForeignKey.DeleteBehavior);
            }
        }
    }
}
