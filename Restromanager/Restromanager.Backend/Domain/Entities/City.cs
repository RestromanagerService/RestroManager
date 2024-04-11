using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;
        public int StateId { get; set; }
        public State? State { get; set; }
    }
}
