namespace WebAppTesteEntrevista01.Helper
{
    public interface ISessao
    {
        void CreateSessionUser(Models.Usuario usuario);
        void RemoveSessionUser();
        Models.Usuario GetSessionUser();
    }
}
