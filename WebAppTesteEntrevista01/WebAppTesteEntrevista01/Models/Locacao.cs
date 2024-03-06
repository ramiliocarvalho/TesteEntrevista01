using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTesteEntrevista01.Models
{
    public class Locacao
    {
        [Key()]
        public int Id  { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public DateTime DataPrevisaoTerminoSistema { get; set; }
        public DateTime? DataPrevisaoTerminoUsuario { get; set; }
        [ForeignKey("Usuarios")]
        public int UsuarioEntregadorId { get; set; }
        [ForeignKey("Motos")]
        public int MotoId { get; set; }
        [ForeignKey("Planos")]
        public int PlanoId { get; set; }

        public virtual Usuario UsuarioEntregador { get; set; }
        public virtual Moto Moto { get; set; }
        public virtual Plano Plano { get; set; }
    }
}
