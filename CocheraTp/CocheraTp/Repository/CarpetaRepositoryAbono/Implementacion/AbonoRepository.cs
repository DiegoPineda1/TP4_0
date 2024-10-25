
using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryAbono.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryAbono.Implementacion
{
    public class AbonoRepository : IAbonoRepository
    {
        private readonly db_cocherasContext _context;
        public AbonoRepository(db_cocherasContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<ABONO>> GetAllAbonos()
        {
            return await _context.ABONOs.ToListAsync();
        }

        public Task<List<ABONO>> GetPromedioAbonos()
        {
            throw new NotImplementedException();
        }
    }
}
