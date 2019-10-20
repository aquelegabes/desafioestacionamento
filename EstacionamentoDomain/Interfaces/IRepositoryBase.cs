using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EstacionamentoDomain.Interfaces
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> @where);
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> @where);
        Task<int> Count(Expression<Func<TEntity, bool>> @where);
        Task<int> Count();
        Task<TEntity> Add(TEntity model);
        Task<TEntity> Update(TEntity model);
        Task<bool> Remove(TEntity model);
        void Dispose();
    }
}