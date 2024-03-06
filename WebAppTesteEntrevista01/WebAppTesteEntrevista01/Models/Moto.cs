using System.ComponentModel.DataAnnotations;

namespace WebAppTesteEntrevista01.Models
{
    public class Moto
    {
        [Key()]
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o ano da moto")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "Digite o modelo da moto")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Digite a placa do moto")]
        public string Placa { get; set; }

        public virtual List<Locacao> Locacoes { get; set; }
    }
}
