using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using PalcoLivre.Data;

namespace PalcoLivre.Pages.Cantor
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public required string Nome { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [Phone(ErrorMessage = "Telefone inválido.")]
        public required string Telefone { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var cantor = new Data.Cantor
            {
                Nome = Nome,
                Telefone = Telefone
            };

            _context.Cantores.Add(cantor);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}