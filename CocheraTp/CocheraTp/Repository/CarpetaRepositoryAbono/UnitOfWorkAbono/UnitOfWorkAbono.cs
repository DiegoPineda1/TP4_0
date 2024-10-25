
using CocheraTp.Repository.CarpetaRepositoryAbono.UnitOfWorkAbono;
using CocheraTp.Repository.CarpetaRepositoryAbono.Interfaces;
using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryAbono.UnitOfWorkAbono
{
    public class UnitOfWorkAbono : IUnitOfWorkAbono
    {
        private readonly db_cocherasContext _context;

        public IAbonoRepository AbonoRepository {  get; }

        public UnitOfWorkAbono(db_cocherasContext context, IAbonoRepository abonoRepository)
        {
            _context = context;
            AbonoRepository = abonoRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
