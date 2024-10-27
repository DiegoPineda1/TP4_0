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
        Task<List<FACTURA?>> GetAllFacturas();
        Task<FACTURA?> GetFacturaById(int id);
        Task<bool> CreateFactura(FACTURA factura);
        Task<bool> UpdateFactura(int id, FACTURA facturaAct);
        Task<bool> DeleteFactura(int id);
    }
}
