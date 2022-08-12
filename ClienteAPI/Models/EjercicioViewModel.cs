using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteAPI.Models
{
    public class EjercicioViewModel
    {
        
      
        public int IdEjercicio { get; set; }
        [Display(Name = "Nombre del ejercicio ")]
        public string NombreEjercicio { get; set; } = null!;

        public string Descripcion { get; set; } = null!;
    }
}
