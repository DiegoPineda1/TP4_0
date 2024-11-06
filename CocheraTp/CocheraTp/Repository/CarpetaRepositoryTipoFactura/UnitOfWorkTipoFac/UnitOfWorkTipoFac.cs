using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryTipoFactura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryTipoFactura.UnitOfWorkTipoFac
{
    public class UnitOfWorkTipoFac : IUnitOfWorkTipoFac
    {
        private readonly db_cocherasContext _context;
        public ITipoFacRepository TipoFacRepository { get; }
        public UnitOfWorkTipoFac(db_cocherasContext context, ITipoFacRepository tipoFacRepository)
        {
            _context = context;
            TipoFacRepository = tipoFacRepository;
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
