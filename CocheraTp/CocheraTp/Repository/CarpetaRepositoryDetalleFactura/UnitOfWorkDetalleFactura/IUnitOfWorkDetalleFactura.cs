using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryFactura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryDetalleFactura.UnitOfWorkDetalleFactura
{
    public interface IUnitOfWorkDetalleFactura : IDisposable
    {
        IDetalleFacturaRepository DetalleFacturaRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
