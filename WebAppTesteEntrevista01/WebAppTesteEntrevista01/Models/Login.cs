using System.ComponentModel.DataAnnotations;

namespace WebAppTesteEntrevista01.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Digite o login")]
        public string User { get; set; }
        [Required(ErrorMessage = "Digite a senha")]   
        public string Password { get; set; }
    }
}
