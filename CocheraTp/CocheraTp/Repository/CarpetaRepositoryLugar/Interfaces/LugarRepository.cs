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

        //public async Task<List<LUGARE>> GetLugaresDisponibles()
        //{
        //    return await _context.LUGAREs.Where(l => l.esta_ocupado == false).ToListAsync();
        //}


        //public async Task<bool> UpdateLugar(string id)
        //{
        //    var lugar = await _context.LUGAREs.FindAsync(id);

        //    if(lugar.esta_ocupado == true)
        //    {
        //        lugar.esta_ocupado = false;
        //        return true;
        //    }
        //    else
        //    {
        //        lugar.esta_ocupado = true;
        //        return true;
        //    }
            
        //}

    }
}
