
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
                    .ThenInclude(d => d.id_abonoNavigation)
                .Include(f => f.id_clienteNavigation)
                .ToListAsync();

            return facturas;
        }

        public async Task<FACTURA?> GetById(int id)
        {
            var f = await _context.FACTURAs.Include(f => f.DETALLE_FACTURAs)
                .Where(f => f.id_factura == id).FirstOrDefaultAsync();

            if (f != null)
                return f;
            return null;
        }

        public async Task<FACTURA?> GetFacturaByPatente(string patente)
        {
            return await _context.FACTURAs
                .Include(f => f.DETALLE_FACTURAs) 
                    .ThenInclude(df => df.id_vehiculoNavigation)
                .Where(f => f.DETALLE_FACTURAs.Any(df => df.id_vehiculoNavigation.patente == patente))
                .FirstOrDefaultAsync();
        }

        public async Task<bool?> Create(FACTURA factura)
        {
            factura.fecha = DateTime.Now;

            var detalle = factura.DETALLE_FACTURAs.First();


            detalle.id_factura = factura.id_factura;
            detalle.fecha_entrada = DateTime.Now;
            detalle.fecha_salida = DateTime.Now;

            detalle.descuento = (detalle.descuento ?? 0) / 100m;
            decimal? descuento = detalle.descuento > 0 ? detalle.descuento : 1;
            decimal recargo = detalle.recargo ?? 0;

            if (detalle.id_abono != 1 && detalle.id_abono != 2 && detalle.id_abono != 3)
            {
                return false;
            }

            switch (detalle.id_abono)
            {
                case 1:
                    detalle.precio = 40000;
                    break;
                case 2:
                    detalle.precio = 25000;
                    break;
                case 3:
                    detalle.precio = 15000;
                    break;
            }

            if (detalle.id_vehiculoNavigation.id_tipo_vehiculoNavigation.descripcion != "Motocicleta" &&
                detalle.id_vehiculoNavigation.id_tipo_vehiculoNavigation.descripcion != "Automovil" &&
                detalle.id_vehiculoNavigation.id_tipo_vehiculoNavigation.descripcion != "Camioneta")
            {
                return false;
            }

            switch (detalle.id_vehiculoNavigation.id_tipo_vehiculoNavigation.descripcion)
            {
                case "Motocicleta":
                    detalle.precio -= 15000;
                    break;
                case "Automovil":
                    break;
                case "Camioneta":
                    detalle.precio += 10000;
                    break;
            }

            detalle.precio = (detalle.precio * (1 - descuento)) + recargo;

            var facturaCreada = await _context.FACTURAs.AddAsync(factura);

            if (facturaCreada != null)
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
