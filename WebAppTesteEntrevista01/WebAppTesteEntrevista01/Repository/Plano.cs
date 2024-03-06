using WebAppTesteEntrevista01.Models;

namespace WebAppTesteEntrevista01.Repository
{
    public class Plano : IPlano
    {
        private readonly Context _context;

        public Plano(Context context)
        {
            _context = context;
        }

        public Models.Plano? GetById(int? id)
        {
            return _context.Planos.FirstOrDefault(m => m.Id == id);
        }

        public List<Models.Plano> List()
        {
            return _context.Planos.ToList();
        }
    }
}
