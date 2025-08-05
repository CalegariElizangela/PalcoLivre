using System.ComponentModel.DataAnnotations;

namespace PalcoLivre.Data
{
    public class Cantor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }
    }
}