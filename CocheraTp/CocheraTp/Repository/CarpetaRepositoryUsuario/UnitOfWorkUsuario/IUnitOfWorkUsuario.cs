using CocheraTp.Repository.CarpetaRepositoryUsuario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryUsuario.UnitOfWorkUsuario
{
    public interface IUnitOfWorkUsuario
    {
        IUsuarioRepository UsuarioRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
