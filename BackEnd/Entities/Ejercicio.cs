using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Ejercicio
    {
        public Ejercicio()
        {
            HistoricoRutinaEjers = new HashSet<HistoricoRutinaEjer>();
        }

        public int IdEjercicio { get; set; }
        public string NombreEjercicio { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<HistoricoRutinaEjer> HistoricoRutinaEjers { get; set; }
    }
}
