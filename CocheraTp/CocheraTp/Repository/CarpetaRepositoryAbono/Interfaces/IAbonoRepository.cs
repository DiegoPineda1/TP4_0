
using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryAbono.Interfaces
{
    public interface IAbonoRepository
    {
        Task<List<ABONO>> GetAllAbonos();
        Task<List<ABONO>> GetPromedioAbonos();
    }
}
