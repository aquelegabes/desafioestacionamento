using System.Collections.Generic;
using System.Threading.Tasks;
using EstacionamentoApplication.Interfaces;
using EstacionamentoDomain.Interfaces;

namespace EstacionamentoApplication.Services
{
    public abstract class CommonService<TEntity> : ICommonService<TEntity>
        where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> repository;
        
        public CommonService (IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<TEntity> Add(TEntity obj) => await repository.Add(obj);

        public virtual async Task<IEnumerable<TEntity>> GetAll() => await repository.GetAll();

        public virtual async Task<TEntity> GetById(int id) => await repository.GetById(id);

        public virtual async Task<TEntity> Update(TEntity obj) => await repository.Update(obj);

        public virtual async Task<bool> Remove (TEntity obj) => await repository.Remove(obj);
    }
}