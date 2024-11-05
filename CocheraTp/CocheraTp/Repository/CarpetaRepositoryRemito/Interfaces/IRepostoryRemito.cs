using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryRemito.Interfaces
{
    public interface IRepostoryRemito
    {
        Task<REMITO> GetRemito(int id);
        Task <bool> AddRemito(REMITO remito);
        Task<List<REMITO>> GetAllRemito();
    }
}
