using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace PalcoLivre.Pages.Cantor
{
    public class CreateModel : PageModel
    {
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

            // Save logic here

            return RedirectToPage("/Index");
        }
    }
}