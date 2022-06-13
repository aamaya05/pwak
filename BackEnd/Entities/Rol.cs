using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            Clientes = new HashSet<Cliente>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
