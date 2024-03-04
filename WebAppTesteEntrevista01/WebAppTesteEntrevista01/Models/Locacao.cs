namespace WebAppTesteEntrevista01.Models
{
    public class Locacao
    {
        public int Id  { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataPrevisaoTerminoSistema { get; set; }
        public DateTime? DataPrevisaoTerminoUsuario { get; set; }
        public int EntregadorId { get; set; }
        public int MotoId { get; set; }
        public int PlanoId { get; set; }
    }
}
