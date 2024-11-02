using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryModelo.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryTipoDocumento.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryTipoDocumento.UnitOfWorkTipoDoc
{
    public class UnitOfWorkTipoDoc : IUnitOfWorkTipoDoc
    {
        private readonly db_cocherasContext _context;
        public ITipoDocRepository TipoDocRepository { get; }
        public UnitOfWorkTipoDoc(db_cocherasContext context, ITipoDocRepository repos)
        {
            _context = context;
            TipoDocRepository = repos;  
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
