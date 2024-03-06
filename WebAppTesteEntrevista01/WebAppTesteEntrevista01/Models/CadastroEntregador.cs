using System.ComponentModel.DataAnnotations;
using WebAppTesteEntrevista01.Enums;

namespace WebAppTesteEntrevista01.Models
{
    public class CadastroEntregador
    {
        [Required(ErrorMessage = "Digite o nome do entregador")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do entregador")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha do entregador")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite o email do entregador")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o perfil do entregador")]
        public PerfilEnums Perfil { get; set; }
        [Required(ErrorMessage = "Digite o CNPJ do entregador")]
        public string Cnpj { get; set;}
        [Required(ErrorMessage = "Digite a data de nascimento do entregador")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Digite o número da CNH do entregador")]
        public string NumeroCnh { get; set; }
        [Required(ErrorMessage = "Selecione o tipo da CNH do entregador")]
        public TipoCnhEnums TipoCnh { get; set; }
        public string? EnderecoImagemCnh { get; set; }
    }
}
