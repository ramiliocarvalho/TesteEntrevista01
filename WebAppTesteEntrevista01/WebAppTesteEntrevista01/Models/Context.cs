using Microsoft.EntityFrameworkCore;

namespace WebAppTesteEntrevista01.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options )
            :base( options )
        { 
        }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public DbSet<Entregador> Entregadores { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<NotificacaoPedido> NotificacoesPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Situacao> Situacoes { get; set; }
    }
}
