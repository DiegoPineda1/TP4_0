
using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryFactura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryFactura.Implementacion
{
    public class FacturaRepository : IFacturaRepository
    {
        db_cocherasContext _context;

        public FacturaRepository(db_cocherasContext context)
        {
            _context = context;
        }

        public Task<bool> Create(FACTURA factura)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FACTURA>> GetAll()
        {
            var facturas = await _context.FACTURAs
                .Include(f => f.DETALLE_FACTURAs)
                    .ThenInclude(d => d.id_vehiculoNavigation)
                        .ThenInclude(v => v.id_tipo_vehiculoNavigation)
                .Include(f => f.DETALLE_FACTURAs)
                    .ThenInclude(d => d.id_abonoNavigation)
                .Include(f => f.id_clienteNavigation)
                .ToListAsync();

            return facturas;
        }

        public Task<FACTURA> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, FACTURA df)
        {
            throw new NotImplementedException();
        }
    }
}
