namespace WebAppTesteEntrevista01.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataCricao { get; set; }
        public decimal ValorCorrida { get; set; }
        public int SituacaoId { get; set; }
        public int? EntregadorId { get; set; }
        public DateTime? DataAceite { get; set; }
        public DateTime? DataEntrega { get; set; }
    }
}
