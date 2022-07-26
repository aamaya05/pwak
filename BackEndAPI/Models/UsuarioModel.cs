using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class UsuarioModel
    {
        //TODO CHECK WHAT ADITIONAL TYPES OF VALIDATIONS WE NEED TO DO IN THE BACKEND USER MODEL

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public int Cedula { get; set; }
        public int Telefono { get; set; }

        [Required]
        public int IdRol { get; set; }


    }
}
