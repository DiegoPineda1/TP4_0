using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryFormaPago.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryFormaPago.Implementacion
{
    public class FormaPagoRepository : IFormaPagoRepository
    {
        private readonly db_cocherasContext _context;
        public FormaPagoRepository(db_cocherasContext context)
        {
            _context = context;
        }

        public async Task<List<FORMAS_DE_PAGO>> GetAllFormaPago()
        {
            return await _context.FORMAS_DE_PAGOs.ToListAsync();
        }
    }
}
