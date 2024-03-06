namespace WebAppTesteEntrevista01.Repository
{
    public interface ILocacao
    {
        List<Models.Locacao> List();

        Models.Locacao? GetById(int? id);

        Models.Moto? GetMotoDisponivel();

        bool Create(Models.CotacaoLocacao locacao);
    }
}
