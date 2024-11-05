using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryDetalleFactura.Interfaces
{
    public interface IDetalleFacturaRepository
    {
        Task<List<DETALLE_FACTURA?>> GetAll();
        Task<IEnumerable<DETALLE_FACTURA>> GetDetallesByFacturaId(int facturaId);
        Task<bool> Create(DETALLE_FACTURA factura);
        Task<bool> Update(int id, DETALLE_FACTURA DF);
        Task<bool> DeleteById(int id);
    }
}
