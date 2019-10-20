using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstacionamentoApplication.Interfaces
{
    public interface ICommonService<TEntity> 
        where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        Task<bool> Remove(TEntity obj);
    }
}