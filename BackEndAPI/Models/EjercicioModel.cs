using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class EjercicioModel
    {
        [Required]
        public int IdEjercicio { get; set; }

        [Required]
        public string NombreEjercicio { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
