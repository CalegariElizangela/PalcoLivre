using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using PalcoLivre.Data;

namespace PalcoLivre.Pages.Cliente
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
        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public required string Email { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var cliente = new Data.Cliente
            {
                Nome = Nome,
                Email = Email
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}