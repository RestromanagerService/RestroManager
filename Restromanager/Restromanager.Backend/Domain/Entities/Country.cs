using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "País")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        public ICollection<State>? States { get; set; }
        [Display(Name ="Departamentos")]

        public int StatesNumber => States==null || States.Count==0 ? 0: States.Count;

    }
}
