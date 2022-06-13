using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class HistoricoRutina
    {
        public HistoricoRutina()
        {
            HistoricoRutinaEjers = new HashSet<HistoricoRutinaEjer>();
        }

        public int IdHistRutina { get; set; }
        public int IdRutina { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Rutina IdRutinaNavigation { get; set; } = null!;
        public virtual ICollection<HistoricoRutinaEjer> HistoricoRutinaEjers { get; set; }
    }
}
