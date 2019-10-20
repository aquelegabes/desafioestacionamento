using System;
using System.Threading.Tasks;
using EstacionamentoApplication.Interfaces;
using EstacionamentoDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EstacionamentoApp.Pages.Registros
{
    public class CreateModel : PageModel
    {
        private readonly IRegistroService service;

        [BindProperty]
        public Registro Registro { get ;set; }

        [BindProperty]
        public string ErrorMessage { get;set; }

        public CreateModel(IRegistroService service){
            this.service = service;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var model = Registro;
            if (!ModelState.IsValid)
                return Page();

            model.Id = 0;
            model.Chegada = DateTime.Now;
            try {
                var result = await service.Add(model);
                return RedirectToPage("/Index");
            }
            catch (Exception ex) {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
}