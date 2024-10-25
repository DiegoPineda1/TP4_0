
using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryVehiculo.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryVehiculo.UnitofWorkVehiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryVehiculo.UnitofWorkVehiculo
{
    public class UnitOfWorkVehiculo : IUnitOfWorkVehiculo
    {
        private readonly db_cocherasContext _context;
        public IVehiculoRepository vehiculoRepository { get; }

        public UnitOfWorkVehiculo(db_cocherasContext context, IVehiculoRepository vehiculoRepository)
        {
            _context = context;
            this.vehiculoRepository = vehiculoRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
