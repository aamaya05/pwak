namespace ClienteAPI.Models
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public int Telefono { get; set; }
        public int IdRol { get; set; }

        // public virtual Rol IdRolNavigation { get; set; } = null!;
        //public virtual ICollection<Rutina> Rutinas { get; set; }
    }
}
