using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class TypeIncome
    {
        public int Id { get; set; }
        [Display(Name = "Tipo de ganancia")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;
        public ICollection<Income>? Incomes { get; set; }
    }
}
