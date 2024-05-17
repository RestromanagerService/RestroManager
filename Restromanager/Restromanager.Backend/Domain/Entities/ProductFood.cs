using Restromanager.Backend.Domain.Entities.Measures;
using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class ProductFood
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public required double Amount { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int UnitsId { get; set; }
        public Unit? Units { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int FoodId { get; set; }
        public Food? Food { get; set; }
    }
}
