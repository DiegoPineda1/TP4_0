using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.CondicionesIVAServicio
{
    public interface ICondicionesIVAService
    {
        Task<List<IVA_CONDICIONE>> GetAllCondiciones();
    }
}
