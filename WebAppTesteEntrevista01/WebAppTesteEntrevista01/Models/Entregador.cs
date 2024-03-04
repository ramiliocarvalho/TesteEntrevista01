namespace WebAppTesteEntrevista01.Models
{
    public class Entregador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set;}
        public DateTime DataNascimento { get; set; }
        public int NumeroCnh { get; set; }
        public int TipoCnh { get; set; }
        public string EnderecoImagemCnh { get; set; }
    }
}
