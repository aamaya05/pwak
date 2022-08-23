using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nombre de Usuario ")]
        public string UserName { get; set; }


        [Display(Name = "Contraseña")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
