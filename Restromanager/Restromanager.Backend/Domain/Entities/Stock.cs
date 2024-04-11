using Restromanager.Backend.Domain.Entities.Measures;
using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int RawMaterialId { get; set; }
        public RawMaterial? RawMaterial { get; set; }
        public int Aumount { get; set; }
        public int UnitsId { get; set; }
        public Unit Units { get; set; } = null!;
        public double UnitCost { get; set; }
    }
}
