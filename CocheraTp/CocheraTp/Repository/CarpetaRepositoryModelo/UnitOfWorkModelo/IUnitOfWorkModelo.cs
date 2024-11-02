using CocheraTp.Repository.CarpetaRepositoryMarca.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryModelo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryModelo.UnitOfWorkModelo
{
    public interface IUnitOfWorkModelo
    {
        IModeloRepository ModeloRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
