
using CocheraTp.Repository.CarpetaRepositoryAbono.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryAbono.UnitOfWorkAbono
{
    public interface IUnitOfWorkAbono : IDisposable
    {
        IAbonoRepository AbonoRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
