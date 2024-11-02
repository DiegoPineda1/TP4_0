using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryTipoDocumento.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryTipoDocumento.Implementacion
{
    public class TipoDocRepository : ITipoDocRepository
    {
        private readonly db_cocherasContext _context;
        public TipoDocRepository(db_cocherasContext context)
        {
            _context = context;
        }
        public async Task<List<TIPOS_DOC>> GetAllTiposDocumento()
        {
            return await _context.TIPOS_DOCs.ToListAsync();
        }
    }
}
