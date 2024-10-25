
using CocheraTp.Repository.CarpetaRepositoryLugar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryLugar.UnitofWorkLugar
{
    public interface IUnitOfWorkLugar
    {
        ILugarRepository LugarRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
