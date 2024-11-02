using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryCondicionIVA.Interfaces
{
    public interface ICondicionesIVARepository
    {
        Task<List<IVA_CONDICIONE>> GetAllCondiciones();
    }
}
