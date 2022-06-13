using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Rutinas = new HashSet<Rutina>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public int Telefono { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual ICollection<Rutina> Rutinas { get; set; }
    }
}
