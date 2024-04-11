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

        public ICollection<Food>? Foods { get; set; }
        [Display(Name = "Alimentos")]
        public int FoodsNumber => Foods == null ? 0 : Foods.Count;
        public double ProductionCost { get; set; }
        public ICollection<Category>? Categories { get; set; }
        [Display(Name = "Categorias")]
        public int CategoriesNumber => Categories == null ? 0 : Categories.Count;
    }
}
