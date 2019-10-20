using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionamentoApplication.Interfaces;
using EstacionamentoDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EstacionamentoApp.Pages.Registros
{
    public class EditModel : PageModel
    {
        private readonly IRegistroService service;
        private readonly IVigenciaService vigenciaService;

        [BindProperty]
        public Registro Registro {get;set;}
        public string ErrorMessage {get;set;}

        public EditModel(IRegistroService service, IVigenciaService vigenciaService)
        {
            this.service = service;
            this.vigenciaService = vigenciaService;
        }
        public async void OnGet(int? id)
        {
            if (id != 0 && id != null)
                Registro = await service.GetById(id.Value);
        }

        public async Task<IActionResult> OnPost()
        {
            var model = Registro;
            if (!ModelState.IsValid)
                return Page();

            try {
                CalculaValor(model);
                var result = await service.Update(model);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }

        public async Task<IActionResult> OnGetSaida(int? id)
        {
            if (id.HasValue){
                var model = await service.GetById(id.Value);
                if (model.Saida.HasValue)
                    return RedirectToPage("/Index");
                model.Saida = DateTime.Now;
                CalculaValor(model);                
                var result = await service.Update(model);
            }
            return RedirectToPage("/Index");
        }

        private async void CalculaValor(Registro model)
        {
            model.Duracao = model.Saida?.Subtract(model.Chegada);
            var vigencia = await vigenciaService.GetPeriodoVigente();
            model.Preco = vigencia.ValorHora;

            if (model.Duracao?.Hours < 1 && model.Duracao?.Minutes <= 30)
                model.ValorTotal = vigencia.ValorHora / 2;
            else if (model.Duracao?.Hours >= 1 && model.Duracao?.Minutes <= 10)
                model.ValorTotal = vigencia.ValorHora + ((model.Duracao?.Hours - 1) * vigencia.HoraAdicional);
            else
                model.ValorTotal = vigencia.ValorHora + model.Duracao?.Hours * vigencia.HoraAdicional;
            
            model.TempoCobrado = model.Duracao?.Hours + (model.Duracao?.Minutes <= 10 ? 0 : 1);
        }
    }
}