using CocheraTp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryLugar.Interfaces
{
    public class LugarRepository : ILugarRepository
    {
        private readonly db_cocherasContext _context;
        public LugarRepository(db_cocherasContext context)
        {
            _context = context;
        }
        public async Task<List<LUGARE>> GetAllLugares()
        {
            return await _context.LUGAREs.ToListAsync();

        }

        public async Task<List<LUGARE>> GetLugaresDisponibles()
        {
            return await _context.LUGAREs.Where(l => l.esta_ocupado == false).ToListAsync();
        }


        public async Task<bool> UpdateLugar(int id, bool estaOcupado)
        {
            var lugar = await _context.LUGAREs.FindAsync(id);
            if (lugar != null)
            {
                lugar.esta_ocupado = estaOcupado;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
