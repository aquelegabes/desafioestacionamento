using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionamentoApplication.Interfaces;
using EstacionamentoDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EstacionamentoApp.Pages.Vigencias
{
    public class EditModel : PageModel
    {
        public IVigenciaService service;
        public EditModel(IVigenciaService service){
            this.service = service;
        }

        [BindProperty]
        public Vigencia Vigencia {get;set;}

        [BindProperty]
        public string ErrorMessage {get;set;}

        public async void OnGet(int? id)
        {
            if (id != null && id != 0)
                Vigencia = await service.GetById(id.Value);
        }

        public async Task<IActionResult> OnPost()
        {
            var model = Vigencia;
            if (!ModelState.IsValid)
                return Page();
            
            try {
                var result = await service.Update(model);
                return RedirectToPage("./Index");
            }
            catch (SystemException ex) 
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }
    }
}