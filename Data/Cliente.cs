using System.ComponentModel.DataAnnotations;

namespace PalcoLivre.Data
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}