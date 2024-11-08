using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryTipoFactura.UnitOfWorkTipoFac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.TipoFacServicio
{
    public class TipoFacService : ITipoFacService
    {
        private readonly IUnitOfWorkTipoFac _unitOfWorkTipoFac;
        public TipoFacService(IUnitOfWorkTipoFac unitOfWorkTipoFac)
        {
            _unitOfWorkTipoFac = unitOfWorkTipoFac;
        }

        public async Task<List<TIPOS_FACTURA>> GetAllTipoFactura()
        {
            return await _unitOfWorkTipoFac.TipoFacRepository.GetAllTipoFactura();  
        }
    }
}
