using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstacionamentoApplication.Interfaces;
using EstacionamentoDomain.Entities;
using EstacionamentoDomain.Interfaces;

namespace EstacionamentoApplication.Services
{
    public class RegistroService : CommonService<Registro>, IRegistroService
    {
        public RegistroService(IRepositoryRegistro repository) : base (repository) { }

        public new async Task<IEnumerable<Registro>> GetAll() => await repository.Where(w => w.Ativo);

        public async Task<IEnumerable<Registro>> SearchByPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                throw new ArgumentException(
                    message: "A placa deve ser preenchida!",
                    paramName: nameof(placa)                    
                );
            }
            
            return await repository.Where(w => 
                w.Placa.Contains(placa,StringComparison.OrdinalIgnoreCase)
                && w.Ativo);
        }
    }
}