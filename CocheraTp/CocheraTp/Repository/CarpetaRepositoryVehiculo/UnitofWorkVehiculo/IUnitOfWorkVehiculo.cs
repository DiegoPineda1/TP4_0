
using CocheraTp.Repository.CarpetaRepositoryVehiculo.Interfaces;

namespace CocheraTp.Repository.CarpetaRepositoryVehiculo.UnitofWorkVehiculo
{
    public interface IUnitOfWorkVehiculo
    {
        IVehiculoRepository vehiculoRepository { get; }
        Task<int> SaveChangesAsync();
    }
}