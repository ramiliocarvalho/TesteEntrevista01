using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Plugins;
using WebAppTesteEntrevista01.Models;

namespace WebAppTesteEntrevista01.Repository
{
    public class Usuario : IUsuario
    {
        private readonly Context _context;

        public Usuario(Context context)
        {
            _context = context;
        }

        public Models.Usuario Create(Models.Usuario usuario)
        {
            usuario.DataCadastro = DateTime.UtcNow;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public CadastroEntregador CreateEntregador(CadastroEntregador entregador)
        {
            throw new NotImplementedException();
        }

        public List<Models.Usuario> List()
        {
            return _context.Usuarios.ToList();
        }

        public Models.Usuario? GetById(int? id)
        {
            return _context.Usuarios.FirstOrDefault(m => m.Id == id);
        }

        public Models.Usuario? GetByLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(m => m.Login.ToLower() == login.ToLower());
        }

        public Models.Usuario Edit(Models.Usuario usuario)
        {
            var usuarioDb = GetById(usuario.Id);

            if (usuarioDb == null) throw new Exception("Houve erro na atualização do usuário");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Senha = usuario.Senha;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAlteracao = DateTime.UtcNow;

            _context.Update(usuarioDb);
            _context.SaveChanges();

            return usuarioDb;
        }

        public bool Delete(int id)
        {
            var usuarioDb = GetById(id);

            if (usuarioDb == null) throw new Exception("Houve erro na exclusão do usuário");

            _context.Usuarios.Remove(usuarioDb);
            _context.SaveChanges();

            return true;
        }

        public Models.Entregador? GetEntregadorById(int id)
        {
            return _context.Entregadores
                .Include(u => u.Usuario)
                .FirstOrDefault(e => e.UsuarioId == id);
        }

        public Models.Entregador? GetByCnpj(string cnpj)
        {
            return _context.Entregadores
                .Include(u => u.Usuario)
                .FirstOrDefault(e => e.Cnpj.ToLower() == cnpj.ToLower());
        }

        public Models.Entregador? GetByCnh(string cnh)
        {
            return _context.Entregadores
                .Include(u => u.Usuario)
                .FirstOrDefault(e => e.NumeroCnh.ToLower() == cnh.ToLower());
        }

        public bool SetImageCnh(int id, string path)
        {
            var entregadorDb = _context.Entregadores.FirstOrDefault(e => e.UsuarioId == id);
            if (entregadorDb == null) throw new Exception("Houve erro na atualização da imagem da CNH");

            entregadorDb.EnderecoImagemCnh = path;

            _context.Update(entregadorDb);
            _context.SaveChanges();

            return true;
        }

    }
}
