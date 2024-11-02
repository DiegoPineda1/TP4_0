using CocheraTp.Repository.CarpetaRepositoryModelo.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryTipoDocumento.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryTipoDocumento.UnitOfWorkTipoDoc
{
    public interface IUnitOfWorkTipoDoc
    {
        ITipoDocRepository TipoDocRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
