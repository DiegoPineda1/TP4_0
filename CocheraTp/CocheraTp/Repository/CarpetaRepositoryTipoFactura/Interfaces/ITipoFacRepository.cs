using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryTipoFactura.Interfaces
{
    public interface ITipoFacRepository
    {
        Task<List<TIPOS_FACTURA>> GetAllTipoFactura();
    }
}
