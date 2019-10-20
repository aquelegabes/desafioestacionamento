using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionamentoDomain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EstacionamentoApplication.Interfaces;
using EstacionamentoDomain.Entities;

namespace EstacionamentoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRegistroService service;
        public IndexModel(IRegistroService service)
        {
            this.service = service;
        }
        public IEnumerable<Registro> Registros { get; set; }

        [BindProperty]
        public string placa { get;set; }
        public async void OnGet(string query)
        {
            placa = Request.QueryString.HasValue ? Request.QueryString.Value.Split('=')[1] : "";
            if (String.IsNullOrWhiteSpace(placa))
                Registros = await service.GetAll();
            else
                Registros = await service.SearchByPlaca(placa);
        }
        
        public async Task<IActionResult> OnGetDelete(int? id)
        {
            if (id.HasValue)
            {
               await service.Remove(await service.GetById(id.Value));
            }
            
            return RedirectToPage("Index");
        }
    }
}
