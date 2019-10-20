using System.Collections.Generic;
using System.Threading.Tasks;
using EstacionamentoDomain.Entities;

namespace EstacionamentoApplication.Interfaces
{
    public interface IRegistroService : ICommonService<Registro>
    {
        Task<IEnumerable<Registro>> SearchByPlaca(string placa);
    }
}