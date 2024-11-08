using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryTipoVehiculo.Interface
{
    public interface ITipoVehiculoRepository
    {
        Task<List<TIPOS_VEHICULO>> GetAllTipoVehiculo();
    }
}
