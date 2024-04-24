using System.ComponentModel.DataAnnotations;

namespace Restromanager.Backend.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }

        [Display(Name = "Reporte")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Descripción")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Description { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public UserReport? UserReport { get; set; } = null!;
        public TypeReport? TypeReport { get; set; } 


        [Display(Name =  "Nombre del gráfico")]
        [MaxLength(255, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string ChartName { get; set; } = null!;
        public string LabelName { get; set; } = null!;
        public decimal LabelValue { get; set; }
    }
}