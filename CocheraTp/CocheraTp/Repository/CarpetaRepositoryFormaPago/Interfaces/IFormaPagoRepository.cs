using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryFormaPago.Interfaces
{
    public interface IFormaPagoRepository
    {
        Task<List<FORMAS_DE_PAGO>> GetAllFormaPago();
    }
}
