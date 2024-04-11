using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities.Measures
{
    public class Unit
    {
        public int Id { get; set; }
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;
        public string Symbol { get; set; }= null!;
    }
}
