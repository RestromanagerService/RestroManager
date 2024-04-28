using Restromanager.Backend.Domain.Entities.Measures;
using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class StockRawMaterial
    {
        public int Id { get; set; }
        public int RawMaterialId { get; set; }
        public RawMaterial? RawMaterial { get; set; }
        public double Aumount { get; set; }
        public int UnitsId { get; set; }
        public Unit? Units { get; set; }
        public double UnitCost { get; set; }
    }
}
