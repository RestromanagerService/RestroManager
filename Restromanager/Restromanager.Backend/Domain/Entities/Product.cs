using Restromanager.Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restromanager.Backend.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Producto")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
        public ProductType ProductType { get; set; }
        [Display(Name = "Alimentos")]
        public ICollection<ProductFood>? ProductFoods { get; set; }

        public int ProductFoodsNumber => ProductFoods == null ? 0 : ProductFoods.Count;
        public double ProductionCost { get; set; }
        [Display(Name = "Categorias")]
        public ICollection<ProductCategory>? ProductCategories { get; set; }
        [Display(Name = "Foto")]
        public string Photo { get; set; } = null!;
        public int ProductCategoriesNumber => ProductCategories == null ? 0 : ProductCategories.Count;

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Price { get; set; }
        public ICollection<TemporalOrder>? TemporalOrders { get; set; }


    }
}
