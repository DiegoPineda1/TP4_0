﻿
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
        public async Task<List<FACTURA?>> GetAll()
        {
            var facturas = await _context.FACTURAs
                .Include(f => f.DETALLE_FACTURAs)
                    .ThenInclude(d => d.id_vehiculoNavigation)
                        .ThenInclude(v => v.id_tipo_vehiculoNavigation)
                .Include(f => f.DETALLE_FACTURAs)
                    .ThenInclude(d => d.id_vehiculoNavigation)
                        .ThenInclude(v => v.id_modeloNavigation)
                .Include(f => f.DETALLE_FACTURAs)
                    .ThenInclude(d => d.id_lugarNavigation)
                .Include(f => f.DETALLE_FACTURAs)
                    .ThenInclude(d => d.id_abonoNavigation)
                .Include(f => f.id_clienteNavigation)
                .Include(f => f.id_tipo_facturaNavigation)
                .Include(f => f.id_usuarioNavigation)
                .ToListAsync();

            return facturas;
        }

        public async Task<FACTURA?> GetById(int id)
        {
            var f = await _context.FACTURAs.FindAsync(id);
            if (f != null)
                return f;
            return null;
        }

        public async Task<bool> Create(FACTURA factura)
        {
            if (await _context.FACTURAs.AddAsync(factura) != null)
                return true;
            return false;
        }

        public async Task<bool> DeleteById(int id)
        {
            var f = await _context.FACTURAs.FindAsync(id);

            if (f != null)
                if (_context.FACTURAs.Remove(f) != null)
                    return true;
            return false;
        }

        public async Task<bool> Update(int id, FACTURA? f)
        {
            f = await _context.FACTURAs.FindAsync(id);
            if (f != null)
                if (_context.FACTURAs.Update(f) != null)
                    return true;
            return false;
        }
    }
}
