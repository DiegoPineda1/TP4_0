using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.ModeloServicio
{
    public interface IModeloService
    {
        Task<bool> GuardarModelo(MODELO modelo);
        Task<List<MODELO>> GetAllModelos();
        Task<List<MODELO>> GetAllByMarca(int idMarca);
    }
}
