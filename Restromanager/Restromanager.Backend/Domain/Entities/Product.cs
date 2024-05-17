using Restromanager.Backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Producto")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;
        public ProductType ProductType { get; set; }
        public ICollection<ProductFood>? ProductFoods { get; set; }
        [Display(Name = "Alimentos")]
        public int ProductFoodsNumber => ProductFoods == null ? 0 : ProductFoods.Count;
        public double ProductionCost { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
        [Display(Name = "Categorias")]
        public int ProductCategoriesNumber => ProductCategories == null ? 0 : ProductCategories.Count;
    }
}
