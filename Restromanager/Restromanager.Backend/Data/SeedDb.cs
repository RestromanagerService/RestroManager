using Microsoft.AspNetCore.Mvc;
using Restromanager.Backend.Data;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Domain.Entities.Measures;

namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly Dictionary<string, Unit> _units = [];
        private readonly Dictionary<string, RawMaterial> _rawMaterials = [];
        private readonly Dictionary<string, Food> _foods = [];
        private readonly Dictionary<string, Product> _products = [];
        private readonly Dictionary<string, Report> _reports = [];

        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
            CreateDataUnits();
            await CheckUnitsAsync();
            CreateDataRawMaterials();
            await CheckRawMaterialsAsync();
            CreateDataFoods();
            await CheckFoodsAsync();
            CreateDataProducts();
            await CheckProductsAsync();
            await CheckStockCommercialProductsAsync();
            await CheckStockRawMaterialsAsync();
            await CheckReportsAsync();
            //await CheckTypesReportsAsync();
            //await CheckUserReportAsync();

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
                    LabelValue = 1.2005m

                });
                _context.Reports.Add(new Report
                {
                    Name = "Reporte de Abril",
                    Description = "Este es el reporte de Abril",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Juliana" },
                    TypeReport = ventas,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.0248m

                });
                _context.Reports.Add(new Report
                {
                    Name = "Reporte de febrero 2",
                    Description = "Este es el reporte de febrero",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Sandra" },
                    TypeReport = ventas,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.43248m

                });
                _context.Reports.Add(new Report
                {
                    Name = "Reporte de marzo 2",
                    Description = "Este es el reporte de marzo",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Ibeth" },
                    TypeReport = nomina,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.43248m

                });
                _context.Reports.Add(new Report
                {
                    Name = "Reporte de Enero 1",
                    Description = "Este es el reporte de Enero 1",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Alberto" },
                    TypeReport = nomina,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.4348m

                });
                _context.Reports.Add(new Report
                {
                    Name = "Reporte de Enero 2",
                    Description = "Este es el reporte de Enero 2",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Karen" },
                    TypeReport = nomina,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.4248m

                });

                _context.Reports.Add(new Report
                {
                    Name = "Reporte de febrero 3",
                    Description = "Este es el reporte de febrero 3",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Alejandra" },
                    TypeReport = nomina,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.4348m

                });

                _context.Reports.Add(new Report
                {
                    Name = "Reporte de marzo 4",
                    Description = "Este es el reporte de marzo",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Viany" },
                    TypeReport = nomina,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.4328m

                });
                _context.Reports.Add(new Report
                {
                    Name = "Reporte de abril 4",
                    Description = "Este es el reporte de abril 4",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Marcos" },
                    TypeReport = nomina,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.43256m

                });
                _context.Reports.Add(new Report
                {
                    Name = "Reporte de abril 5",
                    Description = "Este es el reporte de abril",
                    CreatedDate = DateTime.Now,
                    UserReport = new UserReport { Name = "Julian" },
                    TypeReport = nomina,
                    ChartName = "Gráfico de barras",
                    LabelName = "Día de la semana",
                    LabelValue = 1.495m

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
                ProductFoods = [
                    new ProductFood{ Food = _foods["ArrozCocido"],Units=_units
                        ["Unidad"],Amount=1.0},
                    new ProductFood{ Food = _foods["Frijoles"],Units=_units
                        ["Unidad"],Amount=1.0},
                    new ProductFood{ Food = _foods["Chicharron"],Units=_units
                        ["Unidad"],Amount=1.0}
                ]
            });
            _products.Add("GaseosaManzana300ml", new Product { Name = "Gaseosa de manzana 300ml" });
            _products.Add("GaseosaMandarina300ml", new Product { Name = "Gaseosa de mandarina 300ml" });
            _products.Add("GaseosaUva300ml", new Product { Name = "Gaseosa de uva 300ml" });
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
            if(!_context.Countries.Any()) {
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
