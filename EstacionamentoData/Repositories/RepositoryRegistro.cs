using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using EstacionamentoData.Context;
using EstacionamentoDomain.Entities;
using EstacionamentoDomain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoData.Repositories
{
    public class RepositoryRegistro : RepositoryBase<Registro>, IRepositoryRegistro
    {
        public RepositoryRegistro (EstacionamentoContext context) : base (context) { }

        public new async Task<int> Count() => await this.Count(w => w.Ativo);

        public new async Task<bool> Remove(Registro model)
        {
            if (model == null)
                throw new ArgumentNullException(
                    message: "Cannot update a null reference",
                    paramName: nameof(model));

            try
            {
                model.Ativo = false;
                _context.Set<Registro>().Update(model);
                await _context.SaveChangesAsync();
                return true;
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
    }
}