using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class Income
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public decimal Amount { get; set; }
        public required string Description { get; set; }
        // FK - TypeIncome
        public int TypeIncomeId { get; set; }
        public TypeIncome? TypeIncome { get; set; }
    }
}
