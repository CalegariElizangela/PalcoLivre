using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using PalcoLivre.Data;
using System.Collections.Generic;
using System.Linq;

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
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;

        public List<PalcoLivre.Data.Cliente> Clientes { get; set; } = new();

        public void OnGet()
        {
            Clientes = _context.Clientes.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Clientes = _context.Clientes.ToList();
                return Page();
            }

            if (Id > 0)
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Id == Id);
                if (cliente != null)
                {
                    cliente.Nome = Nome;
                    cliente.Email = Email;
                    _context.SaveChanges();
                    TempData["ShowConfirmation"] = "true";
                }
            }
            else
            {
                var cliente = new PalcoLivre.Data.Cliente
                {
                    Nome = Nome,
                    Email = Email
                };
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                TempData["ShowConfirmation"] = "true";
            }

            return RedirectToPage("/Cliente/Create");
        }
    }
}