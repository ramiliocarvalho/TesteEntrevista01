using System.ComponentModel.DataAnnotations;
using WebAppTesteEntrevista01.Enums;

namespace WebAppTesteEntrevista01.Models
{
    public class Usuario
    {
        [Key()]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite o email do usuário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o perfil do usuário")]
        public PerfilEnums Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public virtual Entregador Entregador { get; set; }
        public virtual List<Locacao> Locacoes { get; set; }
        public bool IsPasswordValid(string password)
        {
            return Senha.ToLower() == password.ToLower();
        }
    }
}
