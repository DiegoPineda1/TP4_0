using CocheraTp.Models;

namespace CocheraTp.Servicios.VehiculoServicio
{
    public interface IVehiculoServicio
    {
        Task<List<VEHICULO>> GetAllVehiculos();
        Task<VEHICULO> GetVehiculoById(int id);
        Task<bool> CreateVehiculo(VEHICULO vehiculo);
        Task<bool> UpdateVehiculo(int id, VEHICULO vehiculo);
        Task<bool> DeleteVehiculo(int id);
    }
}