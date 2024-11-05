using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.RemitoServicio
{
    public interface IRemitoServicio
    {
        Task<REMITO> GetRemito(int id);
        Task<bool> AddRemito(REMITO remito);
        Task<List<REMITO>> GetAllRemito();
    }
}
