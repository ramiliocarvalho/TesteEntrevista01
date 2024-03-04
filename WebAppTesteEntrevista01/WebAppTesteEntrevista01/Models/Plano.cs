namespace WebAppTesteEntrevista01.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int NumeroDias { get; set; }
        public decimal ValorDia { get; set; }
        public decimal ValorDiariaAdicional { get; set; }
        public int PorcentagemDiariaNaoEfetivada { get; set; }

    }
}
