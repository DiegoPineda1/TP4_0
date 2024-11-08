using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.TipoFacServicio
{
    public interface ITipoFacService
    {
        Task<List<TIPOS_FACTURA>> GetAllTipoFactura();
    }
}
