using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryLugar.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryMarca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryMarca.UnitOfWorkMarca
{
    public class UnitOfWorkMarca : IUnitOfWorkMarca
    {
        private readonly db_cocherasContext _context;
        public IMarcaRepository MarcaRepository { get; }

        public UnitOfWorkMarca(db_cocherasContext context, IMarcaRepository repos)
        {
            _context = context;
            MarcaRepository = repos;
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
