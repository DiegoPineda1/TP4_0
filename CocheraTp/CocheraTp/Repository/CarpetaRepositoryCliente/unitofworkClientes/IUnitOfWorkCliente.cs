
using CocheraTp.Repository.CarpetaRepositoryCliente.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryCliente.unitofworkClientes
{
    public interface IUnitOfWorkCliente : IDisposable
    {
        IClienteRepository ClienteRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
