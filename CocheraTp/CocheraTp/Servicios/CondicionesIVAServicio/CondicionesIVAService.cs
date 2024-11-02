using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryCondicionIVA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.CondicionesIVAServicio
{
    public class CondicionesIVAService : ICondicionesIVAService
    {
        private readonly ICondicionesIVARepository _condicionesIVARepository; 

        public CondicionesIVAService(ICondicionesIVARepository condicionesIVARepository)
        {
            _condicionesIVARepository = condicionesIVARepository; 
        }

        public async Task<List<IVA_CONDICIONE>> GetAllCondiciones()
        {
            return await _condicionesIVARepository.GetAllCondiciones(); 
        }
    }
}
