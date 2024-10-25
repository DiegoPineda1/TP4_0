
using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryCliente.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryCliente.unitofworkClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.unit_of_work
{ 
    public class UnitOfWorkCliente : IUnitOfWorkCliente
    {
        private readonly db_cocherasContext _context;
        public IClienteRepository ClienteRepository { get; }

        public UnitOfWorkCliente(db_cocherasContext context, IClienteRepository clienteRepository)
        {
            _context = context;
            ClienteRepository = clienteRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
