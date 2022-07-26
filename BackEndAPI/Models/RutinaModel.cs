using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class RutinaModel
    {
        //TODO CHECK WHAT ADITIONAL TYPES OF VALIDATIONS WE NEED TO DO IN THE ROUTINE MODEL

        public int IdRutina { get; set; }

        [Required]
        public string NombreRutina { get; set; } = null!;

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdUsuario { get; set; }

    }
}
