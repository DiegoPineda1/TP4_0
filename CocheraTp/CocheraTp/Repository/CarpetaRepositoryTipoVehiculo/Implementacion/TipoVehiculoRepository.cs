using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryTipoVehiculo.Interface;
using Microsoft.EntityFrameworkCore;


namespace CocheraTp.Repository.CarpetaRepositoryTipoVehiculo.Implementacion
{
    public class TipoVehiculoRepository : ITipoVehiculoRepository
    {
        private readonly db_cocherasContext _context;
        public TipoVehiculoRepository(db_cocherasContext context)
        {
            _context = context;
        }
        public async Task<List<TIPO_VEHICULO>> GetAllTipoVehiculo()
        {
            return await _context.TIPO_VEHICULOs.ToListAsync();
        }
    }
}
