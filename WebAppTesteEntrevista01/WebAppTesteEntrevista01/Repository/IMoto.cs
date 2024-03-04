namespace WebAppTesteEntrevista01.Repository
{
    public interface IMoto
    {
        Models.Moto Create(Models.Moto moto);

        List<Models.Moto> List();

        Models.Moto? Get(int? id);

        Models.Moto Edit(Models.Moto moto);

        bool Delete(int id);
    }
}
