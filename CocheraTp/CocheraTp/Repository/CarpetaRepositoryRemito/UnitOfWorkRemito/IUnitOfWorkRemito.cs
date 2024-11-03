using CocheraTp.Repository.CarpetaRepositoryRemito.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryRemito.UnitOfWorkRemito
{
    public interface IUnitOfWorkRemito
    {
        IRepostoryRemito RepostoryRemito { get; }
        Task<int> SaveChangesAsync();
    }
}
