using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.DetalleFacturaServicio
{
    public interface IDetalleFacturaServicio
    {
        Task<List<DETALLE_FACTURA?>> GetAllDetalleFacturas();
        Task<IEnumerable<DETALLE_FACTURA>> GetDetallesByFacturaId(int facturaId);
        Task<bool> CreateDetalleFactura(DETALLE_FACTURA factura);
        Task<bool> UpdateDetalleFactura(int id, DETALLE_FACTURA facturaAct);
        Task<bool> DeleteDetalleFactura(int id);
    }
}
