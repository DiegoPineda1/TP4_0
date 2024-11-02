using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryCondicionIVA.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryCondicionIVA.Implementacion
{
    public class CondicionesIVARepository : ICondicionesIVARepository
    {
        private readonly db_cocherasContext _context;
        public CondicionesIVARepository(db_cocherasContext context)
        {
            _context = context;
        }
        public async Task<List<IVA_CONDICIONE>> GetAllCondiciones()
        {
            return await _context.IVA_CONDICIONEs.ToListAsync();
        }
    }
}
