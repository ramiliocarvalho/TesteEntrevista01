using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAppTesteEntrevista01.Models;

namespace WebAppTesteEntrevista01.Repository
{
    public class Moto : IMoto
    {
        private readonly Context _context;

        public Moto(Context context) 
        { 
            _context = context;
        }

        public Models.Moto Create(Models.Moto moto)
        {
            _context.Motos.Add(moto);
            _context.SaveChanges();

            return moto;
        }

        public List<Models.Moto> List()
        {
            return _context.Motos.ToList();
        }

        public Models.Moto? GetById(int? id)
        {
            return _context.Motos.FirstOrDefault(m => m.Id == id);
        }

        public Models.Moto Edit(Models.Moto moto)
        {
            var motoDb = GetById(moto.Id);

            if (motoDb == null) throw new Exception("Houve erro na atualização da moto");

            motoDb.Placa = moto.Placa;
            
            _context.Update(motoDb);
            _context.SaveChanges();

            return motoDb;
        }

        public bool Delete(int id)
        {
            var motoDb = GetById(id);

            if (motoDb == null) throw new Exception("Houve erro na exclusão da moto");

            _context.Motos.Remove(motoDb);
            _context.SaveChanges();

            return true;
        }

        public Models.Moto? GetByPlaca(string placa)
        {
            return _context.Motos.FirstOrDefault(m => m.Placa.ToLower() == placa.ToLower());
        }
    }
}
