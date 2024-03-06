namespace WebAppTesteEntrevista01.Repository
{
    public interface IUsuario
    {
        Models.Usuario Create(Models.Usuario usuario);

        Models.CadastroEntregador CreateEntregador(Models.CadastroEntregador entregador);

        List<Models.Usuario> List();

        Models.Usuario? GetById(int? id);

        Models.Entregador? GetEntregadorById(int id);

        Models.Usuario? GetByLogin(string login);

        Models.Usuario Edit(Models.Usuario usuario);

        bool Delete(int id);

        Models.Entregador? GetByCnpj(string cnpj);

        Models.Entregador? GetByCnh(string cnh);

        bool SetImageCnh(int id, string path);
    }
}
