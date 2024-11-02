using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryMarca.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryMarca.Implementacion
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly db_cocherasContext _context;
        public MarcaRepository(db_cocherasContext context)
        {
            _context = context;
        }
        //public async Task<List<MARCA>> GetAllByMarca(string nombreMarca)
        //{
        //    return await _context.MARCAs
        //                         .Where(m => m.nombre_marca.Contains(nombreMarca))
        //                         .ToListAsync();
        //}

        public async Task<List<MARCA>> GetAllMarcas()
        {
            return await _context.MARCAs.ToListAsync();
        }

        public async Task<bool> GuardarMarca(MARCA marca)
        {
            await _context.MARCAs.AddAsync(marca);
            return true;
        }
    }
}
