using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.UnitOfWorkDetalleFactura;
using CocheraTp.Repository.CarpetaRepositoryFactura.UnitOfWorkFactura;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.DetalleFacturaServicio
{
    public class DetalleFacturaServicio : IDetalleFacturaServicio
    {
        private readonly IUnitOfWorkDetalleFactura _unitOfWork;
        public DetalleFacturaServicio(IUnitOfWorkDetalleFactura unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateDetalleFactura(DETALLE_FACTURA df)
        {
            var agregado = await _unitOfWork.DetalleFacturaRepository.Create(df);
            if (agregado)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteDetalleFactura(int id)
        {
            var eliminado = await _unitOfWork.DetalleFacturaRepository.DeleteById(id);
            if (eliminado)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<DETALLE_FACTURA?>> GetAllDetalleFacturas()
        {
            return await _unitOfWork.DetalleFacturaRepository.GetAll();
        }

        public async Task<IEnumerable<DETALLE_FACTURA>> GetDetallesByFacturaId(int facturaId)
        {
            return await _unitOfWork.DetalleFacturaRepository.GetDetallesByFacturaId(facturaId);
        }

        public async Task<bool> UpdateDetalleFactura(int id, DETALLE_FACTURA dfActualizado)
        {
            var actualizado = await _unitOfWork.DetalleFacturaRepository.Update(id, dfActualizado);
            if (actualizado)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
