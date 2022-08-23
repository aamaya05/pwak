using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Models
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Requerido")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "Requerido")]
        public string Apellido1 { get; set; } = null!;

        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "Requerido")]
        public string Apellido2 { get; set; } = null!;

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "Requerido")]
        public string Cedula { get; set; } = null!;

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Requerido")]
        public int Telefono { get; set; }

        public int IdRol { get; set; } = 2;

        // public virtual Rol IdRolNavigation { get; set; } = null!;
        //public virtual ICollection<Rutina> Rutinas { get; set; }
    }
}
