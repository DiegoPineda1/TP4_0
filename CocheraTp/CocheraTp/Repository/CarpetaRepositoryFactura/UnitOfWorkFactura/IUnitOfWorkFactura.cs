
using CocheraTp.Repository.CarpetaRepositoryFactura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryFactura.UnitOfWorkFactura
{
    public interface IUnitOfWorkFactura : IDisposable
    {
        IFacturaRepository FacturaRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
