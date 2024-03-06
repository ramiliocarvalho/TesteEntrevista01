namespace WebAppTesteEntrevista01.Repository
{
    public interface IMoto
    {
        Models.Moto Create(Models.Moto moto);

        List<Models.Moto> List();

        Models.Moto? GetById(int? id);

        Models.Moto? GetByPlaca(string placa);

        Models.Moto Edit(Models.Moto moto);

        bool Delete(int id);
    }
}
