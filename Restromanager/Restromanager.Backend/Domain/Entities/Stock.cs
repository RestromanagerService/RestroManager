using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }

        [Display(Name = "Existencias")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;


        public ICollection<Product>? Products { get; set; }
        [Display(Name = "Productos")]
        public int ProductsNumber => Products == null ? 0 : Products.Count;

        public ICollection<RawMaterial>? RawMaterials { get; set; }
        [Display(Name = "Materias primas")]
        public int RawMaterialsNumber => RawMaterials == null ? 0 : RawMaterials.Count;
    }
}
