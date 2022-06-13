using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class HistoricoRutinaEjer
    {
        public int IdHisRutEjer { get; set; }
        public int IdHistRutina { get; set; }
        public int IdEjercicio { get; set; }
        public int Repeticiones { get; set; }
        public int Series { get; set; }
        public int Descanso { get; set; }

        public virtual Ejercicio IdEjercicioNavigation { get; set; } = null!;
        public virtual HistoricoRutina IdHistRutinaNavigation { get; set; } = null!;
    }
}
