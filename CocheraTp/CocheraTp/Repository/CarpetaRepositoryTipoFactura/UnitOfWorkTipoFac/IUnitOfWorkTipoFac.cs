using CocheraTp.Repository.CarpetaRepositoryTipoFactura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryTipoFactura.UnitOfWorkTipoFac
{
    public interface IUnitOfWorkTipoFac
    {
        ITipoFacRepository TipoFacRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
