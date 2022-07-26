using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class HistoricoRutinaEjercicioModel
    {
        [Required]
        public int IdHisRutEjer { get; set; }

        [Required]
        public int IdHistRutina { get; set; }

        [Required]
        public int IdEjercicio { get; set; }
        public int Repeticiones { get; set; }
        public int Series { get; set; }
        public int Descanso { get; set; }
    }
}
