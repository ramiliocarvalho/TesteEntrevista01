namespace WebAppTesteEntrevista01.Repository
{
    public interface IPlano
    {
        List<Models.Plano> List();

        Models.Plano? GetById(int? id);
    }
}
