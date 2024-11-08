using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryTipoVehiculo.Interface;

namespace CocheraTp.Servicios.TipoVehiculoService
{
    public class TipoVehiculoService : ITipoVehiculoService
    {
        private readonly ITipoVehiculoRepository _tipoVehiculo;
        public TipoVehiculoService(ITipoVehiculoRepository tipoVehiculo)
        {
            _tipoVehiculo = tipoVehiculo;
        }
        public async Task<List<TIPOS_VEHICULO>> GetAllTipoVehiculo()
        {
            return await _tipoVehiculo.GetAllTipoVehiculo();
        }
    }
}
