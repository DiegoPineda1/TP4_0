using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryDetalleFactura.Implementacion
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        db_cocherasContext _context;

        public DetalleFacturaRepository(db_cocherasContext context)
        {
            _context = context;
        }

        public async Task<List<DETALLE_FACTURA?>> GetAll()
        {
            var detalleFactura = await _context.DETALLE_FACTURAs.ToListAsync();

            return detalleFactura;
        }

        public async Task<IEnumerable<DETALLE_FACTURA>> GetDetallesByFacturaId(int facturaId)
        {
            return await _context.DETALLE_FACTURAs
                                 .Where(df => df.id_factura == facturaId)
                                 .ToListAsync();
        }

        public async Task<DETALLE_FACTURA?> GetById(int id)
        {
            var df = await _context.DETALLE_FACTURAs.FindAsync(id);
            if (df != null)
                return df;
            return null;
        }

        public async Task<bool> Create(DETALLE_FACTURA df)
        {
            if (await _context.DETALLE_FACTURAs.AddAsync(df) != null)
                return true;
            return false;
        }

        public async Task<bool> DeleteById(int id)
        {
            var df = await _context.DETALLE_FACTURAs.FindAsync(id);

            if (df != null)
                if (_context.DETALLE_FACTURAs.Remove(df) != null)
                    return true;
            return false;
        }

        public async Task<bool> Update(int id, DETALLE_FACTURA? df)
        {
            df = await _context.DETALLE_FACTURAs.FindAsync(id);
            if (df != null)
                if (_context.DETALLE_FACTURAs.Update(df) != null)
                    return true;
            return false;
        }
    }
}
