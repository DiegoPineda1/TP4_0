using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.FormaPagoServicio
{
    public interface IFormaPagoService
    {
        Task<List<FORMAS_DE_PAGO>> GetAllFormaPago();
    }
}
