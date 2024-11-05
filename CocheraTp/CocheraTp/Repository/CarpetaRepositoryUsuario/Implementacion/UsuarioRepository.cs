using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryUsuario.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryUsuario.Implementacion
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly db_cocherasContext _context;
        public UsuarioRepository(db_cocherasContext context) { 
            _context = context;
        }
        public async Task<List<USUARIO>> GetAllUsuario()
        {
            return await _context.USUARIOs.ToListAsync();
        }
    }
}
