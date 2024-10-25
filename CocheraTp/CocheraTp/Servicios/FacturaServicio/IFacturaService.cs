using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.FacturaServicio
{
    public interface IFacturaService
    {
        Task<List<FACTURA>> GetAllFacturas();
        Task<FACTURA> GetFacturaById(int id);
        Task<bool> CreateCliente(FACTURA factura);
        Task<bool> Update(int id, FACTURA facturaAct);
        Task<bool> Delete(int id);
    }
}
