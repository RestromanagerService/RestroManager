using Restromanager.Backend.Domain.Entities.Measures;
using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class FoodRawMaterial
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public required double Amount { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int UnitsId { get; set; }
        public Unit? Units { get; set; }
        public int FoodId { get; set; }
        public Food? Food { get; set; }
        public int RawMaterialId { get; set; }
        public RawMaterial? RawMaterial { get; set; }

    }


}
