using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryFactura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryDetalleFactura.UnitOfWorkDetalleFactura
{
    public class UnitOfWorkDetalleFactura : IUnitOfWorkDetalleFactura
    {
        private readonly db_cocherasContext _context;
        public IDetalleFacturaRepository DetalleFacturaRepository { get; }

        public UnitOfWorkDetalleFactura(db_cocherasContext context, IDetalleFacturaRepository repos)
        {
            _context = context;
            DetalleFacturaRepository = repos;
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
