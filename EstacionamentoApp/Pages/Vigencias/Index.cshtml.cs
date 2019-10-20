using System.Collections.Generic;
using System.Threading.Tasks;
using EstacionamentoApplication.Interfaces;
using EstacionamentoDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EstacionamentoApp.Pages.Vigencias
{
    public class IndexModel : PageModel
    {
        private readonly IVigenciaService service;
        public IEnumerable<Vigencia> Vigencias { get;set; }

        public IndexModel(IVigenciaService service){
            this.service = service;
        }

        public async void OnGet()
        {
            Vigencias = await service.GetAll();
        }

        public async Task<IActionResult> OnGetDelete(int? id)
        {
            if (id.HasValue)
            {
               await service.Remove(await service.GetById(id.Value));
            }
            
            return RedirectToPage("./Index");
        }
    }
}