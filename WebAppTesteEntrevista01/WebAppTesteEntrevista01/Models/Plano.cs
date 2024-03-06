using System.ComponentModel.DataAnnotations;

namespace WebAppTesteEntrevista01.Models
{
    public class Plano
    {
        [Key()]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int NumeroDiaria { get; set; }
        public decimal ValorDiaria { get; set; }
        public decimal ValorDiariaAdicional { get; set; }
        public int PorcentagemDiariaNaoEfetivada { get; set; }
        public virtual List<Locacao> Locacoes { get; set; }
    }
}
