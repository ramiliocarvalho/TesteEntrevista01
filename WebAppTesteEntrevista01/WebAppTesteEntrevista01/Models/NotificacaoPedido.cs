namespace WebAppTesteEntrevista01.Models
{
    public class NotificacaoPedido
    {
        public int Id { get; set; }
        public DateTime DataNotificacao { get; set; }
        public int EntregadorId { get; set; }
        public int PedidoId { get; set; }
    }
}
