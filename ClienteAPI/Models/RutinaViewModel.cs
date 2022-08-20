using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteAPI.Models
{
    public class RutinaViewModel
    {
        public int IdRutina { get; set; }
        [Display(Name = "Nombre de la rutina ")]
        public string NombreRutina { get; set; } = null!;
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }

    }
}
