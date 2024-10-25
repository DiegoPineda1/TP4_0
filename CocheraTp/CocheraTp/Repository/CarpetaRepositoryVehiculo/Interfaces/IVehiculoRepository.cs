
using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryVehiculo.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<List<VEHICULO>> GetAllVehiculos();
        Task<VEHICULO> GetVehiculoById(int id);
        Task<bool> CreateVehiculo(VEHICULO vehiculo);
        Task<bool> UpdateVehiculo(int id,VEHICULO vehiculo);
        Task<bool> DeleteVehiculo(int id);
    }
}
