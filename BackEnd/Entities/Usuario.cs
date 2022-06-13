using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Bitacoras = new HashSet<Bitacora>();
            Rutinas = new HashSet<Rutina>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public int Cedula { get; set; }
        public int Telefono { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual ICollection<Bitacora> Bitacoras { get; set; }
        public virtual ICollection<Rutina> Rutinas { get; set; }
    }
}
