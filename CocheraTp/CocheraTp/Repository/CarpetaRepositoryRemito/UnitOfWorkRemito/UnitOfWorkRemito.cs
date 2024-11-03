using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryRemito.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryRemito.UnitOfWorkRemito
{
    public class UnitOfWorkRemito : IUnitOfWorkRemito
    {
        private readonly db_cocherasContext _context;
        public IRepostoryRemito _repostoryRemito;
        public UnitOfWorkRemito(db_cocherasContext db_CocherasContext, IRepostoryRemito repostoryRemito)
        {
            _context = db_CocherasContext;
            _repostoryRemito = repostoryRemito;
        }

        public IRepostoryRemito RepostoryRemito => _repostoryRemito;

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
