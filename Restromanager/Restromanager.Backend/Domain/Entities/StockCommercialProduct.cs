using Restromanager.Backend.Domain.Entities.Measures;

namespace Restromanager.Backend.Domain.Entities
{
    public class StockCommercialProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public double Aumount { get; set; }
        public int UnitsId { get; set; }
        public Unit Units { get; set; } = null!;
        public double UnitCost { get; set; }
    }
}
