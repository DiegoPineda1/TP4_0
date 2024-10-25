
using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryVehiculo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryVehiculo.Implementacion
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly db_cocherasContext _Context;
        public VehiculoRepository(db_cocherasContext _CocherasContext)
        {
            _Context = _CocherasContext;
        }
        public async Task<bool> CreateVehiculo(VEHICULO vehiculo)
        {
            await _Context.VEHICULOs.AddAsync(vehiculo);
            return true;
        }

        public async Task<bool> DeleteVehiculo(int id)
        {
            var vehiculo = await _Context.VEHICULOs.FindAsync(id);
            if (vehiculo != null)
            {
                _Context.VEHICULOs.Remove(vehiculo);
                return true;
            }
            return false;
        }

        public async Task<List<VEHICULO>> GetAllVehiculos()
        {
            return await _Context.VEHICULOs.ToListAsync();
        }

        public async Task<VEHICULO> GetVehiculoById(int id)
        {
            return await _Context.VEHICULOs.FindAsync(id);
        }

        public async Task<bool> UpdateVehiculo(int id, VEHICULO vehiculo)
        {
            var vehiculo1 = await _Context.VEHICULOs.FindAsync(id);
            if (vehiculo1 != null)
            {
                _Context.Entry(vehiculo1).CurrentValues.SetValues(vehiculo);
                return true;
            }
            return false;
        }
    }
}
