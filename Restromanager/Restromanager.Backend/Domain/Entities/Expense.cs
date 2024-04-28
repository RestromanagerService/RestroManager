using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public decimal Amount { get; set; }
        public required string Description { get; set; }
        // FK - TypeExpense
        public int TypeExpenseId { get; set; }
        public TypeExpense? TypeExpense { get; set; }

    }
}
