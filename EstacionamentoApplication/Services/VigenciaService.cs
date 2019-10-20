using System.Threading.Tasks;
using EstacionamentoApplication.Interfaces;
using EstacionamentoDomain.Entities;
using EstacionamentoDomain.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;

namespace EstacionamentoApplication.Services
{
    public class VigenciaService : CommonService<Vigencia>, IVigenciaService
    {
        public VigenciaService (IRepositoryVigencia repository) : base (repository) { }

        public new async Task<IEnumerable<Vigencia>> GetAll() => await repository.Where(w => w.Ativo);

        public override async Task<Vigencia> Add(Vigencia obj)
        {
            var all = await repository.Count();
            if (obj.VigenciaFim.Date < obj.VigenciaInicio.Date)
                throw new SystemException("A data final deve ser maior que a data início!");

            var find = await repository.Where(
                w => (obj.VigenciaFim.Date < w.VigenciaInicio.Date
                    || obj.VigenciaInicio.Date > w.VigenciaFim)
                    || (obj.VigenciaFim.Date <= w.VigenciaFim.Date
                        && obj.VigenciaInicio >= w.VigenciaInicio.Date)
                    && obj.Ativo
            );

            if (!find.Any() && all > 0)
                throw new SystemException(
                    message: "Não é possível adicionar outra vigência dentro de um período já existente!"
                );
            
            return await base.Add(obj);
        }
        public override async Task<Vigencia> Update(Vigencia obj)
        {
            var all = await repository.Count();
            if (obj.VigenciaFim.Date < obj.VigenciaInicio.Date)
                throw new SystemException("A data final deve ser maior que a data início!");
                
            var find = await this.repository.Where(
                w => (obj.VigenciaFim.Date < w.VigenciaInicio.Date
                    || obj.VigenciaInicio.Date > w.VigenciaFim)
                    || (obj.VigenciaFim.Date <= w.VigenciaFim.Date
                        && obj.VigenciaInicio >= w.VigenciaInicio.Date)
                    && w.Id != obj.Id && w.Ativo
            );

            if (!find.Any() && all > 0)
                throw new SystemException(
                    message: "Não é possível adicionar outra vigência dentro de um período já existente!"
                );
            return await base.Update(obj);
        }

        public async Task<Vigencia> GetPeriodoVigente()
        {
            var today = DateTime.Now.Date;
            var vigencia =  await this.repository.Where(w => 
                   w.VigenciaInicio.Date <= today 
                && w.VigenciaFim.Date >= today
                && w.Ativo
            );
            return vigencia.First();
        }
    }
}