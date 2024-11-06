using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryFormaPago.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryFormaPago.UnitOfWorkFormaPago
{
    public class UnitOfWorkFormaPago : IUnitOfWorkFormaPago
    {
        private readonly db_cocherasContext _CocherasContext;
        public IFormaPagoRepository FormaPagoRepository { get; }
        public UnitOfWorkFormaPago(db_cocherasContext cocherasContext, IFormaPagoRepository formaPagoRepository)
        {
            _CocherasContext = cocherasContext;
            FormaPagoRepository = formaPagoRepository;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _CocherasContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _CocherasContext.Dispose();
        }
    }
}
