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

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicial { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan HoraFinal { get; set; }
    }
}
