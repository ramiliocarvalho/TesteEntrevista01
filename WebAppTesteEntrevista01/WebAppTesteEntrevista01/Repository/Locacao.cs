using Microsoft.EntityFrameworkCore;
using WebAppTesteEntrevista01.Models;

namespace WebAppTesteEntrevista01.Repository
{
    public class Locacao : ILocacao
    {
        private readonly Context _context;

        public Locacao(Context context)
        {
            _context = context;
        }

        public Models.Locacao? GetById(int? id)
        {
            return _context.Locacoes
                .Include(u => u.UsuarioEntregador)
                .Include(m => m.Moto)
                .Include(p => p.Plano)
                .FirstOrDefault(m => m.Id == id);
        }

        public List<Models.Locacao> List()
        {
            return _context.Locacoes
                .ToList();
        }

        public Models.Moto? GetMotoDisponivel()
        {
            var motosAlugadas = _context.Locacoes
                .Where(m => m.DataTermino == null)
                .Select(m => m.MotoId)
                .ToList();

            return _context.Motos.
                FirstOrDefault(m => !motosAlugadas.Contains(m.Id));
        }

        public bool Create(CotacaoLocacao locacao)
        {


            throw new NotImplementedException();
        }
    }
}
