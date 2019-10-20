using System.Threading.Tasks;
using EstacionamentoDomain.Entities;

namespace EstacionamentoApplication.Interfaces
{
    public interface IVigenciaService : ICommonService<Vigencia>
    {
        Task<Vigencia> GetPeriodoVigente();
    }
}