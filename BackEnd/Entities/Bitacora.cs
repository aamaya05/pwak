using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Bitacora
    {
        public int IdEvento { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
