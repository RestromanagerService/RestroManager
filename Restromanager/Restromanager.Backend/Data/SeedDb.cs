using Microsoft.EntityFrameworkCore;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Domain.Entities.Measures;
using Restromanager.Backend.Enums;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Orders.Backend.Data
{
    public class SeedDb(DataContext context, IUserUnitOfWork userUnitOfWork)
    {
        private readonly IUserUnitOfWork _userUnitOfWork = userUnitOfWork;
        private readonly DataContext _context = context;

        private readonly Dictionary<string, Unit> _units = [];
        private readonly Dictionary<string, RawMaterial> _rawMaterials = [];
        private readonly Dictionary<string, Food> _foods = [];
        private readonly Dictionary<string, Product> _products = [];
        private readonly Dictionary<string, TypeExpense> _typeExpenses = [];
        private readonly List<Expense> _expenses = new List<Expense>();
        private readonly Dictionary<string, TypeIncome> _typeIncomes = [];
        private readonly List<Income> _incomes = new List<Income>();
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            //await CheckCountriesAsync();
            await CheckCountriesFullAsync();
            await CheckTablesAsync();
            await CheckProductsSQL();
            CreateDataTypeExpenses();
            await CheckTypeExpenseAsync();
            await CheckExpensesAsync();
            CreateDataTypeIncomes();
            await CheckTypeIncomeAsync();
            await CheckIncomeAsync();
            await CheckReportsAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Andrés", "Peñaloza", "sebbppe@yopmail.com", "3161249203", "Calle 12", "Cúcuta", UserType.Admin, "https://orderssebas20241.blob.core.windows.net/users/d7fc526e-2ec4-4ae9-b41c-043851af1d2a.jpg");
            await CheckUserAsync("1011", "Oskar", "Guzmán", "oskar@yopmail.com", "3121421312", "Calle 13", "Cúcuta", UserType.Admin, "https://orderssebas20241.blob.core.windows.net/users/cd691ce7-eff0-4e35-8934-489435b34828.jpg");
            await CheckUserAsync("1011", "Andrés", "Serrano", "andres@yopmail.com", "3121421312", "Calle 14", "Barranquilla", UserType.Admin, "https://orderssebas20241.blob.core.windows.net/users/5cd555ec-d29e-4d46-b871-077bd0a4e971.jpg");
            await CheckUserAsync("1011", "homero", "simpson", "homero@yopmail.com", "3121421312", "Calle 14", "Barranquilla", UserType.Chef, "https://orderssebas20241.blob.core.windows.net/users/68061a49-cd2f-45e5-bf3f-3d9d5a89ad57.jpg");
            await CheckUserAsync("1011", "Goku", "Peñaloza", "goku@yopmail.com", "3121421312", "Calle 14", "Barranquilla", UserType.Waiter, "https://orderssebas20241.blob.core.windows.net/users/da60be1a-a00a-4b94-8f54-b0a50907fbfa.jpg");
            await CheckUserAsync("1011", "Ana", "Rendón", "ana@yopmail.com", "3121421312", "Calle 14", "Barranquilla", UserType.User, "https://orderssebas20241.blob.core.windows.net/users/9dca68da-98a8-4d28-950e-84b4f5ffcfda.jpg");
            //await CheckTypesReportsAsync();
            //await CheckUserReportAsync();

        }
        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, string userCity, UserType userType,string photo)
        {
            var user = await _userUnitOfWork.GetUserAsync(email);
            if (user == null)
            {
                var city = await _context.Cities.FirstOrDefaultAsync(x => x.Name == userCity);
                city ??= await _context.Cities.FirstOrDefaultAsync();

                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = city,
                    UserType = userType,
                    Photo= photo
                };
                await _userUnitOfWork.AddUserAsync(user, "123456");
                await _userUnitOfWork.AddUserToRoleAsync(user, userType.ToString());
                var token = await _userUnitOfWork.GenerateEmailConfirmationTokenAsync(user);
                await _userUnitOfWork.ConfirmEmailAsync(user, token);

            }
            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userUnitOfWork.CheckRoleAsync(UserType.Admin.ToString());
            await _userUnitOfWork.CheckRoleAsync(UserType.Chef.ToString());
            await _userUnitOfWork.CheckRoleAsync(UserType.Waiter.ToString());
            await _userUnitOfWork.CheckRoleAsync(UserType.User.ToString());
        }
        private async Task CheckCountriesFullAsync()
        {
            if (!_context.Countries.Any())
            {
                var countriesStatesCitiesSQLScript = File.ReadAllText("Data\\CountriesStatesCities.sql");
                await _context.Database.ExecuteSqlRawAsync(countriesStatesCitiesSQLScript);
            }

        }
        private async Task CheckProductsSQL()
        {
            if (!_context.Products.Any())
            {
                var productsSQLScript = File.ReadAllText("Data\\DataProducts.sql");
                await _context.Database.ExecuteSqlRawAsync(productsSQLScript);
            }

        }
        private async Task CheckReportsAsync()
        {
            if (!_context.Reports.Any())
            {
                var ventas = new TypeReport { Name = "Ventas" };
                var nomina = new TypeReport { Name = "Nómina" };

                _context.Reports.Add(new Report
                {
                    Name = "Reporte de Enero",
                    Description = "Este es el reporte de enero",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Carlos" },
                    TypeReport = ventas,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.008m

                });
                _context.Reports.Add(new Report
                {
                    Name = "Reporte de Febrero",
                    Description = "Este es el reporte de Febrero",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Juan" },
                    TypeReport = nomina,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.005m

                });
                _context.Reports.Add(new Report
                {
                    Name = "Reporte de Marzo",
                    Description = "Este es el reporte de Marzo",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Alirio" },
                    TypeReport = ventas,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.005m

                });
                await _context.SaveChangesAsync();
            }
        }

        private void CreateDataUnits()
        {
            _units.Add("Kilogramo", new Unit { Name = "Kilogramo", Symbol = "Kg" });
            _units.Add("Gramo", new Unit { Name = "Gramo", Symbol = "g" });
            _units.Add("Unidad", new Unit { Name = "Unidad", Symbol = "U" });
        }
        private async Task CheckUnitsAsync()
        {
            if (!_context.Units.Any())
            {
                _context.Units.Add(_units["Kilogramo"]);
                _context.Units.Add(_units["Gramo"]);
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckTablesAsync()
        {
            if (!_context.Tables.Any())
            {
                _context.Tables.Add(new Table() { Name = "Mesa 1"});
                _context.Tables.Add(new Table() { Name = "Mesa 2" });
                _context.Tables.Add(new Table() { Name = "Mesa 3" });
                _context.Tables.Add(new Table() { Name = "Mesa 4" });
                _context.Tables.Add(new Table() { Name = "Mesa 5" });
                _context.Tables.Add(new Table() { Name = "Mesa 6" });
                await _context.SaveChangesAsync();
            }
        }

        private void CreateDataTypeExpenses()
        {
            _typeExpenses.Add("Gastos fijos", new TypeExpense { Name = "Gastos fijos" });
            _typeExpenses.Add("Gastos variables", new TypeExpense { Name = "Gastos variables" });
        }
        private async Task CheckTypeExpenseAsync()
        {
            if (!_context.TypeExpenses.Any())
            {
                _context.TypeExpenses.Add(_typeExpenses["Gastos fijos"]);
                _context.TypeExpenses.Add(_typeExpenses["Gastos variables"]);
                await _context.SaveChangesAsync();
            }
        }
        private void CreateDataTypeIncomes()
        {
            _typeIncomes.Add("Ganancias regulares", new TypeIncome { Name = "Ganancias regulares" });
            _typeIncomes.Add("Ganancias NO regulares", new TypeIncome { Name = "Ganancias NO regulares" });
        }

        private async Task CheckTypeIncomeAsync()
        {
            if (!_context.TypeIncomes.Any())
            {
                _context.TypeIncomes.Add(_typeIncomes["Ganancias regulares"]);
                _context.TypeIncomes.Add(_typeIncomes["Ganancias NO regulares"]);
                await _context.SaveChangesAsync();
            }
        }

        private void CreateDataIncomes()
        {
            _incomes.Add(new Income
            {
                Description = "Pago plato 1",
                Amount = 1000m,
                TypeIncomeId = _typeIncomes["Ganancias regulares"].Id
            });

            _incomes.Add(new Income
            {
                Description = "Resultado de ganancia de rifa",
                Amount = 20000m,
                TypeIncomeId = _typeIncomes["Ganancias NO regulares"].Id
            });
        }

        private async Task CheckIncomeAsync()
        {
            if (!_context.Incomes.Any())
            {
                CreateDataIncomes();
                foreach (var income in _incomes)
                {
                    _context.Incomes.Add(income);
                }
                await _context.SaveChangesAsync();
            }
        }


        private void CreateDataExpenses()
        {
            _expenses.Add(new Expense
            {
                Description = "Pago de energía",
                Amount = 1000m,
                TypeExpenseId = _typeExpenses["Gastos fijos"].Id,
            });

            _expenses.Add(new Expense
            {
                Description = "Pago de de fiesta del jefe",
                Amount = 2000m,
                TypeExpenseId = _typeExpenses["Gastos variables"].Id,
            });
        }

        private async Task CheckExpensesAsync()
        {
            if (!_context.Expenses.Any())
            {
                CreateDataExpenses();
                foreach (var expense in _expenses)
                {
                    _context.Expenses.Add(expense);
                }

                await _context.SaveChangesAsync();
            }
        }

        private void CreateDataRawMaterials()
        {
            _rawMaterials.Add("Arroz", new RawMaterial { Name = "Arroz" });
            _rawMaterials.Add("Frijol", new RawMaterial { Name = "Frijol" });
            _rawMaterials.Add("Chicharron", new RawMaterial { Name = "Chicharron de cerdo" });
            _rawMaterials.Add("Tomate", new RawMaterial { Name = "Tomate" });
            _rawMaterials.Add("Cebolla", new RawMaterial { Name = "Cebolla" });
        }
        private async Task CheckRawMaterialsAsync()
        {
            if (!_context.RawMaterials.Any())
            {
                _context.RawMaterials.Add(_rawMaterials["Arroz"]);
                _context.RawMaterials.Add(_rawMaterials["Frijol"]);
                _context.RawMaterials.Add(_rawMaterials["Chicharron"]);
                _context.RawMaterials.Add(_rawMaterials["Tomate"]);
                _context.RawMaterials.Add(_rawMaterials["Cebolla"]);
                await _context.SaveChangesAsync();
            }
        }
        private void CreateDataFoods()
        {
            _foods.Add("ArrozCocido",
                new Food
                {
                    Name = "Porcion de arroz cocido",
                    ProductionCost = 500.0,
                    FoodRawMaterials = [
                new FoodRawMaterial{RawMaterial = _rawMaterials["Arroz"],Units=_units["Gramo"],Amount=300.0},
                new FoodRawMaterial{RawMaterial = _rawMaterials["Tomate"],Units=_units["Gramo"],Amount=20.0},
                new FoodRawMaterial{RawMaterial = _rawMaterials["Cebolla"],Units=_units
                  ["Gramo"],Amount=20.0}
                ]
                });
            _foods.Add("Frijoles", new Food
            {
                Name = "Porcion de frijoles",
                ProductionCost = 600.0,
                FoodRawMaterials = [
                new FoodRawMaterial{RawMaterial = _rawMaterials["Frijol"],Units=_units["Gramo"],Amount=300.0},
                new FoodRawMaterial{RawMaterial = _rawMaterials["Tomate"],Units=_units["Gramo"],Amount=20.0},
                new FoodRawMaterial{RawMaterial = _rawMaterials["Cebolla"],Units=_units
                  ["Gramo"],Amount=20.0}
                ]
            });
            _foods.Add("Chicharron", new Food
            {
                Name = "Porcion de chicharrón",
                ProductionCost = 300.5,
                FoodRawMaterials = [
                new FoodRawMaterial{RawMaterial = _rawMaterials["Chicharron"],Units=_units["Gramo"],Amount=300.0}
                ]
            });
        }
        private async Task CheckFoodsAsync()
        {
            if (!_context.Foods.Any())
            {
                _context.Foods.Add(_foods["ArrozCocido"]);
                _context.Foods.Add(_foods["Frijoles"]);
                _context.Foods.Add(_foods["Chicharron"]);
                await _context.SaveChangesAsync();
            }
        }
        private void CreateDataProducts()
        {
            _products.Add("BandejaPaisa", new Product
            {
                Name = "Bandeja paisa",
                ProductType = ProductType.Recipe,
                ProductFoods = [
                    new ProductFood{ Food = _foods["ArrozCocido"],Units=_units
                        ["Unidad"],Amount=1.0},
                    new ProductFood{ Food = _foods["Frijoles"],Units=_units
                        ["Unidad"],Amount=1.0},
                    new ProductFood{ Food = _foods["Chicharron"],Units=_units
                        ["Unidad"],Amount=1.0}
                ],
                Photo = ""
            });
            _products.Add("GaseosaManzana300ml", new Product { Name = "Gaseosa de manzana 300ml", ProductType = ProductType.Commercial, Photo = "" });
            _products.Add("GaseosaMandarina300ml", new Product { Name = "Gaseosa de mandarina 300ml", ProductType = ProductType.Commercial, Photo = "" });
            _products.Add("GaseosaUva300ml", new Product { Name = "Gaseosa de uva 300ml", ProductType = ProductType.Commercial, Photo = "" });
            _products.Add("LimonadaCerezada", new Product { Name = "Limonada Cerezada", ProductType = ProductType.Commercial, Photo = "" });
            _products.Add("LimonadaNatural", new Product { Name = "Limonada Natural", ProductType = ProductType.Commercial, Photo = "" });
        }

        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                _context.Products.Add(_products["BandejaPaisa"]);
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckStockCommercialProductsAsync()
        {
            if (!_context.StockCommercialProducts.Any())
            {
                _context.StockCommercialProducts.Add(new StockCommercialProduct { Product = _products["GaseosaManzana300ml"], Units = _units["Unidad"], Aumount = 10, UnitCost = 3000.5 });
                _context.StockCommercialProducts.Add(new StockCommercialProduct { Product = _products["GaseosaMandarina300ml"], Units = _units["Unidad"], Aumount = 10, UnitCost = 3000.5 });
                _context.StockCommercialProducts.Add(new StockCommercialProduct { Product = _products["GaseosaUva300ml"], Units = _units["Unidad"], Aumount = 10, UnitCost = 3000.5 });
                _context.StockCommercialProducts.Add(new StockCommercialProduct { Product = _products["LimonadaCerezada"], Units = _units["Unidad"], Aumount = 10, UnitCost = 3000.5 });
                _context.StockCommercialProducts.Add(new StockCommercialProduct { Product = _products["LimonadaNatural"], Units = _units["Unidad"], Aumount = 10, UnitCost = 3000.5 });

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckStockRawMaterialsAsync()
        {
            if (!_context.StockRawMaterials.Any())
            {
                _context.StockRawMaterials.Add(new StockRawMaterial { RawMaterial = _rawMaterials["Arroz"], Units = _units["Gramo"], Aumount = 1000.0, UnitCost = 20 });
                _context.StockRawMaterials.Add(new StockRawMaterial { RawMaterial = _rawMaterials["Frijol"], Units = _units["Gramo"], Aumount = 1000.0, UnitCost = 30 });
                _context.StockRawMaterials.Add(new StockRawMaterial { RawMaterial = _rawMaterials["Chicharron"], Units = _units["Gramo"], Aumount = 1000.0, UnitCost = 20 });
                _context.StockRawMaterials.Add(new StockRawMaterial { RawMaterial = _rawMaterials["Tomate"], Units = _units["Gramo"], Aumount = 1000.0, UnitCost = 10 });
                _context.StockRawMaterials.Add(new StockRawMaterial { RawMaterial = _rawMaterials["Cebolla"], Units = _units["Gramo"], Aumount = 1000.0, UnitCost = 10 });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Entradas" });
                _context.Categories.Add(new Category { Name = "Almuerzos" });
                _context.Categories.Add(new Category { Name = "Bebidas" });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(
                    new Country
                    {
                        Name = "Colombia",
                        States =
                        [
                            new State{Name="Norte de Santander",Cities=[
                                new City{Name="Cúcuta"},
                                new City{Name="Los Patios"},
                                new City{Name="Villa del Rosario"},
                                new City{Name="El Zulia"}
                            ] },
                            new State{Name="Santander",Cities=[
                                new City{Name="Bucaramanga"},
                                new City{Name="Piedecuesta"}
                            ] },
                            new State{Name="Antioquia",Cities=[
                                new City{Name="Medellín"},
                                new City{Name="Envigado"}
                            ] }
                        ]
                    });
                await _context.SaveChangesAsync();
            }
        }
    }
}
