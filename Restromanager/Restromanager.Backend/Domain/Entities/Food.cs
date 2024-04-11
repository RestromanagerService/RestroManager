using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class Food
    {
        public int Id { get; set; }

        [Display(Name = "Alimento")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;
        public ICollection<FoodRawMaterial>? FoodRawMaterials { get; set; }
        [Display(Name = "Materias primas")]
        public int FoodRawMaterialsNumber => FoodRawMaterials == null ? 0 : FoodRawMaterials.Count;
    }
}
