using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppTesteEntrevista01.Enums;

namespace WebAppTesteEntrevista01.Models
{
    public class Entregador
    {
        [Key()]
        public int Id { get; set; }
        [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }
        public string Cnpj { get; set;}
        public DateTime DataNascimento { get; set; }
        public string NumeroCnh { get; set; }
        public TipoCnhEnums TipoCnh { get; set; }
        public string? EnderecoImagemCnh { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
