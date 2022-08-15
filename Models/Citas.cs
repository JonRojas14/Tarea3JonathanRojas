using System.ComponentModel.DataAnnotations;

namespace TareaNo._3_Jonathan_Rojas_3101.Models
{
    public class Citas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor seleccione un Especialidad para poder agendar su cita.")]
        [Display(Name = "Especialidad de la cita:")]
        public string Especialidad { get; set; }

        [Required(ErrorMessage = "Por favor seleccione el dia y la fecha en la que desea agendar su cita.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha y hora para la cita:")]
        public DateTime Cita { get; set; }

        [Display(Name = "Estado de la cita:")]
        public string? Estado { get; set; }

        [Display(Name = "Descripcion breve de la cita (Opcional):")]
        public string? Descripcion { get; set; }

    }
}
