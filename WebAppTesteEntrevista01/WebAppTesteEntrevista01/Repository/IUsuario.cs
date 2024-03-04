namespace WebAppTesteEntrevista01.Repository
{
    public interface IUsuario
    {
        Models.Usuario Create(Models.Usuario usuario);

        List<Models.Usuario> List();

        Models.Usuario? Get(int? id);

        Models.Usuario? GetByLogin(string login);

        Models.Usuario Edit(Models.Usuario usuario);

        bool Delete(int id);
    }
}
