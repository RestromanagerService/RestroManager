using Restromanager.Backend.Domain.Entities.Measures;
using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class FoodRawMaterial
    {
        public int Id { get; set; }
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public required double Amount { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public  Unit Units { get; set; }=null!;
        public int RawMaterialId { get; set; }
        public RawMaterial? RawMaterial { get; set; }
        public int FoodId { get; set; }
        public Food? Food { get; set; }
    }
    
        
}
