using System.ComponentModel.DataAnnotations;

namespace PalcoLivre.Data
{
    public class Cantor
    {
        public int Id { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        [Phone]
        public required string Telefone { get; set; }
    }
}