using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using PalcoLivre.Data;

namespace PalcoLivre.Pages.Agendamento
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "A data do evento é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime? DataEvento { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "O período é obrigatório.")]
        public string? Periodo { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string? Descricao { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var agendamento = new PalcoLivre.Data.Agendamento
            {
                DataEvento = DataEvento ?? DateTime.Today,
                Periodo = Periodo ?? string.Empty,
                Descricao = Descricao ?? string.Empty
            };
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
            TempData["ShowConfirmation"] = "true";
            return RedirectToPage("/Agendamento/Create");
        }
    }
}
