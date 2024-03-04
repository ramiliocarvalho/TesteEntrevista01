﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using NuGet.Packaging.Signing;
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

        public List<Models.Usuario> List()
        {
            return _context.Usuarios.ToList();
        }

        public Models.Usuario? Get(int? id)
        {
            return _context.Usuarios.FirstOrDefault(m => m.Id == id);
        }

        public Models.Usuario? GetByLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(m => m.Login.ToLower() == login.ToLower());
        }

        public Models.Usuario Edit(Models.Usuario usuario)
        {
            var usuarioDb = Get(usuario.Id);

            if (usuarioDb == null) throw new Exception("Houve erro na atualização do usuário");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.DataAlteracao = DateTime.UtcNow;
            usuarioDb.Perfil = usuario.Perfil;

            _context.Update(usuarioDb);
            _context.SaveChanges();

            return usuarioDb;
        }

        public bool Delete(int id)
        {
            var usuarioDb = Get(id);

            if (usuarioDb == null) throw new Exception("Houve erro na exclusão do usuário");

            _context.Usuarios.Remove(usuarioDb);
            _context.SaveChanges();

            return true;
        }
    }
}
