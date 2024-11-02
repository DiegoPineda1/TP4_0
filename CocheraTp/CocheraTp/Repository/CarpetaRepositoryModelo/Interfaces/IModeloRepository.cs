using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryModelo.Interfaces
{
    public interface IModeloRepository
    {
        Task<bool> GuardarModelo(MODELO modelo);
        Task<List<MODELO>> GetAllModelos();
        Task<List<MODELO>> GetAllByMarca(int idMarca);
    }
}
