using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstacionamentoDomain.Interfaces;
using System.Data.Common;
using System.Linq.Expressions;
using System.Linq;
using EstacionamentoData.Context;

#pragma warning disable RCS1090

namespace EstacionamentoData.Repositories
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity>
            where TEntity : class
    {
        protected readonly EstacionamentoContext _context;

        protected RepositoryBase(Context.EstacionamentoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Cannot initialiaze a repository with a null context");
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> where)
        {
            if (where == null)
                throw new ArgumentNullException(nameof(where), "Predicate cannot be null.");
            try
            {
                return await _context.Set<TEntity>().FirstOrDefaultAsync(where);
            }
            catch (DbException ex)
            {
                ex.Data["params"] = new List<object> { where };
                throw;
            }
            catch (ArgumentException ex)
            {
                ex.Data["params"] = new List<object> { where };
                throw;
            }
            catch (Exception ex)
            {
                ex.Data["params"] = new List<object> { where };
                throw;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> where)
        {
            if (where == null)
                throw new ArgumentNullException(nameof(where), "Predicate cannot be null.");

            try
            {
                return await _context.Set<TEntity>().Where(where).ToListAsync();
            }
            catch (DbException ex)
            {
                ex.Data["params"] = new List<object> { where };
                throw;
            }
            catch (ArgumentException ex)
            {
                ex.Data["params"] = new List<object> { where };
                throw;
            }
            catch (Exception ex)
            {
                ex.Data["params"] = new List<object> { where };
                throw;
            }
        }

        public virtual async Task<int> Count() => await _context.Set<TEntity>().CountAsync();

        public async Task<int> Count(Expression<Func<TEntity, bool>> where)
        {
            if (where == null)
                throw new ArgumentNullException(
                    message: "Predicate cannot be null.",
                    paramName: nameof(where));
            
            try 
            {
                return await _context.Set<TEntity>().CountAsync(where);
            }
            catch (ArgumentNullException ex)
            {
                ex.Data["params"] = new List<object> {where};
                throw;
            }
            catch (OverflowException ex)
            {
                ex.Data["params"] = new List<object> {where};
                throw;
            }
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id cannot be zero or lower.", nameof(id));

            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                ex.Data["params"] = new List<object> {id};
                throw;
            }
        }

        public virtual async Task<TEntity> Add(TEntity model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "Cannot add a null reference");

            try
            {
                await _context.Set<TEntity>().AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (DbException ex)
            {
                ex.Data["params"] = new List<object> { model };
                throw;
            }
            catch (Exception ex)
            {
                ex.Data["params"] = new List<object> { model };
                throw;
            }
        }

        public virtual async Task<TEntity> Update(TEntity model)
        {
            if (model == null)
                throw new ArgumentNullException(
                    message: "Cannot update a null reference",
                    paramName: nameof(model));

            try
            {
                _context.Set<TEntity>().Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (EntryPointNotFoundException ex)
            {
                ex.Data["params"] = new List<object> {model};
                throw;
            }
            catch (DbUpdateException ex)
            {
                ex.Data["params"] = new List<object> {model};
                throw;
            }
            catch (DbException ex)
            {
                ex.Data["params"] = new List<object> {model};
                throw;
            }
            catch (Exception ex)
            {
                ex.Data["params"] = new List<object> {model};
                throw;
            }
        }

        public virtual async Task<bool> Remove(TEntity model)
        {
            if (model == null)
                throw new ArgumentNullException(
                    message: "Cannot remove a null object",
                    paramName: nameof(model));

            try
            {
                _context.Set<TEntity>().Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException ex)
            {
                ex.Data["params"] = new List<object> {model};
                throw;
            }
            catch (Exception ex)
            {
                ex.Data["params"] = new List<object> {model};
                throw;
            }
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        
    }
}