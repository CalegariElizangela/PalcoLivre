using System.ComponentModel.DataAnnotations;

namespace PalcoLivre.Data
{
    public class Agendamento
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataEvento { get; set; }

        [Required]
        public string Periodo { get; set; } = string.Empty;

        [Required]
        public string Descricao { get; set; } = string.Empty;
    }
}
