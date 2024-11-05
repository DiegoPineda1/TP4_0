using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryUsuario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryUsuario.UnitOfWorkUsuario
{
    public class UnitOfWorkUsuario : IUnitOfWorkUsuario
    {
        private readonly db_cocherasContext _context;
        public IUsuarioRepository UsuarioRepository { get; }

        public UnitOfWorkUsuario(db_cocherasContext context, IUsuarioRepository usuarioRepository)
        {
            _context = context;
            this.UsuarioRepository = usuarioRepository;
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
