using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteAPI.Models
{
    public class HistoricoRutinaEjercicioViewModel
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
