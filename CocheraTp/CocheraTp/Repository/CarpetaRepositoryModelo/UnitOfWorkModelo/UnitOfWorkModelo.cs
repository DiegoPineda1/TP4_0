using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryModelo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryModelo.UnitOfWorkModelo
{
    public class UnitOfWorkModelo : IUnitOfWorkModelo
    {
        private readonly db_cocherasContext _context;
        public IModeloRepository ModeloRepository { get; }
        public UnitOfWorkModelo(db_cocherasContext context,IModeloRepository repos)
        {
            _context = context;
            ModeloRepository = repos;
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
