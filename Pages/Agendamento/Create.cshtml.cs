using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using PalcoLivre.Data;
using System.Collections.Generic;
using System.Linq;

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
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A data do evento é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime? DataEvento { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "O período é obrigatório.")]
        public string? Periodo { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A hora inicial é obrigatória.")]
        [DataType(DataType.Time)]
        public TimeSpan? HoraInicial { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A hora final é obrigatória.")]
        [DataType(DataType.Time)]
        public TimeSpan? HoraFinal { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string? Descricao { get; set; }

        public List<Data.Agendamento> EventosMes { get; set; } = new();

        public void OnGet()
        {
            var hoje = DateTime.Today;
            var primeiroDia = new DateTime(hoje.Year, hoje.Month, 1);
            var ultimoDia = primeiroDia.AddMonths(1).AddDays(-1);
            EventosMes = _context.Agendamentos
                .Where(a => a.DataEvento >= primeiroDia && a.DataEvento <= ultimoDia)
                .OrderBy(a => a.DataEvento)
                .ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                OnGet();
                return Page();
            }
            if (Id > 0)
            {
                var agendamento = _context.Agendamentos.FirstOrDefault(a => a.Id == Id);
                if (agendamento != null)
                {
                    agendamento.DataEvento = DataEvento ?? DateTime.Today;
                    agendamento.HoraInicial = HoraInicial ?? TimeSpan.Zero;
                    agendamento.HoraFinal = HoraFinal ?? TimeSpan.Zero;
                    agendamento.Periodo = Periodo ?? string.Empty;
                    agendamento.Descricao = Descricao ?? string.Empty;
                    _context.SaveChanges();
                    TempData["ShowConfirmation"] = "true";
                }
            }
            else
            {
                var agendamento = new Data.Agendamento
                {
                    DataEvento = DataEvento ?? DateTime.Today,
                    HoraInicial = HoraInicial ?? TimeSpan.Zero,
                    HoraFinal = HoraFinal ?? TimeSpan.Zero,
                    Periodo = Periodo ?? string.Empty,
                    Descricao = Descricao ?? string.Empty
                };
                _context.Agendamentos.Add(agendamento);
                _context.SaveChanges();
                TempData["ShowConfirmation"] = "true";
            }
            return RedirectToPage("/Agendamento/Create");
        }
    }
}
