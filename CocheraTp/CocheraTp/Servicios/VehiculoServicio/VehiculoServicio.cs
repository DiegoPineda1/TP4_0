using CocheraTp.Repository.CarpetaRepositoryVehiculo.UnitofWorkVehiculo;
using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocheraTp.Servicios.VehiculoServicio;

namespace CocheraTp.Servicios.VehiculoServicio
{
    public class VehiculoServicio : IVehiculoServicio
    {
        private readonly IUnitOfWorkVehiculo _unitOfWorkVehiculo;
        public VehiculoServicio(IUnitOfWorkVehiculo unitOfWorkVehiculo)
        {
            this._unitOfWorkVehiculo = unitOfWorkVehiculo;
        }

        public async Task<bool> CreateVehiculo(VEHICULO vehiculo)
        {
            var creado = await _unitOfWorkVehiculo.vehiculoRepository.CreateVehiculo(vehiculo);
            if (creado)
            {
                await _unitOfWorkVehiculo.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteVehiculo(int id)
        {
            var borrado = await _unitOfWorkVehiculo.vehiculoRepository.DeleteVehiculo(id);
            if (borrado)
            {
                await _unitOfWorkVehiculo.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<VEHICULO>> GetAllVehiculos()
        {
            return await _unitOfWorkVehiculo.vehiculoRepository.GetAllVehiculos();
        }

        public async Task<VEHICULO> GetVehiculoById(int id)
        {
            return await _unitOfWorkVehiculo.vehiculoRepository.GetVehiculoById(id);
        }

        public async Task<bool> UpdateVehiculo(int id, VEHICULO vehiculo)
        {
            var actulizado = await _unitOfWorkVehiculo.vehiculoRepository.UpdateVehiculo(id, vehiculo);
            if (actulizado)
            {
                await _unitOfWorkVehiculo.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
