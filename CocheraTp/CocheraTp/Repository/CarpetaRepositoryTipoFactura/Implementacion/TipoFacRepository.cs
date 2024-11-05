using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryTipoFactura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryTipoFactura.Implementacion
{
    public class TipoFacRepository : ITipoFacRepository
    {
        private readonly db_cocherasContext _context;
        public TipoFacRepository(db_cocherasContext context)
        {
            _context = context;
        }
        public async Task<List<TIPO_FACTURA>> GetAllTipoFactura()
        {
            return await _context.TIPO_FACTURAs.ToListAsync();
        }
    }
}
