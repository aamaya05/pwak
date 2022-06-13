using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Rutina
    {
        public Rutina()
        {
            HistoricoRutinas = new HashSet<HistoricoRutina>();
        }

        public int IdRutina { get; set; }
        public string NombreRutina { get; set; } = null!;
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<HistoricoRutina> HistoricoRutinas { get; set; }
    }
}
