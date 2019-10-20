using System.Threading.Tasks;
using EstacionamentoApplication.Interfaces;
using EstacionamentoDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EstacionamentoApp.Pages.Vigencias
{
    public class CreateModel : PageModel
    {
        private readonly IVigenciaService service;

        [BindProperty]
        public Vigencia Vigencia { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }
        public CreateModel(IVigenciaService service){
            this.service = service;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var model = Vigencia;
            if (!ModelState.IsValid)
                return Page();
            
            model.Id = 0;
            try {
                var result = await service.Add(model);
                return RedirectToPage("./Index");
            }
            catch (SystemException ex){
                ErrorMessage = ex.Message;
            }

            return Page();
        }
    }
}