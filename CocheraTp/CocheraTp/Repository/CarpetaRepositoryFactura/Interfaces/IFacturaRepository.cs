
using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryFactura.Interfaces
{
    public interface IFacturaRepository
    {
        Task<List<FACTURA?>> GetAll();
        Task<FACTURA?> GetById(int id);
        Task<FACTURA?> GetFacturaByPatente(string patente);
        Task<bool> Create(FACTURA? factura);
        Task<bool> Update(int id, FACTURA DF);
        Task<bool> DeleteById(int id);
    }
}
