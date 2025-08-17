using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using PalcoLivre.Data;
using System.Collections.Generic;
using System.Linq;

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
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [Phone(ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; } = string.Empty;

        public List<PalcoLivre.Data.Cantor> Cantores { get; set; } = new();

        public void OnGet()
        {
            Cantores = _context.Cantores.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cantores = _context.Cantores.ToList();
                return Page();
            }

            if (Id > 0)
            {
                var cantor = _context.Cantores.FirstOrDefault(c => c.Id == Id);
                if (cantor != null)
                {
                    cantor.Nome = Nome;
                    cantor.Telefone = Telefone;
                    _context.SaveChanges();
                    TempData["ShowConfirmation"] = "true";
                }
            }
            else
            {
                var cantor = new PalcoLivre.Data.Cantor
                {
                    Nome = Nome,
                    Telefone = Telefone
                };
                _context.Cantores.Add(cantor);
                _context.SaveChanges();
                TempData["ShowConfirmation"] = "true";
            }

            return RedirectToPage("/Cantor/Create");
        }
    }
}