
namespace WebAppTesteEntrevista01.Models
{
    public class CotacaoLocacao
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public DateTime DataPrevisaoTerminoSistema { get; set; }
        public DateTime? DataPrevisaoTerminoUsuario { get; set; }
        public string TotalPagar { get; set; }
        public string TotalPagarAvulso { get; set; }

        public int UsuarioEntregadorId { get; set; }
        public string? NomeEntregador { get; set; }
        public string? EmailEntregador { get; set; }
        public string? Categoria { get; set; }

        public string AnoMoto { get; set; }
        public string? ModeloMoto { get; set; }
        public string? PlacaMoto { get; set; }

        public string? DescricaoPlano { get; set; }
        public int? NumeroDiaria { get; set; }
        public string? ValorDiaria { get; set; }
        public string? ValorDiariaAdicional { get; set; }
        public int? PorcentagemDiariaNaoEfetivada { get; set; }
        public bool IsCotacaoCalculada { get; set; }
        public bool IsMulta { get; set; }
        public bool IsLocacaoDisponivel { get; set; }
    }
}
