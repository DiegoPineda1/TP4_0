using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryModelo.UnitOfWorkModelo;
using CocheraTp.Repository.CarpetaRepositoryTipoDocumento.UnitOfWorkTipoDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.TiposDocServicio
{
    public class TipoDocService : ITipoDocService
    {
        private readonly IUnitOfWorkTipoDoc _unitOfWork;

        public TipoDocService(IUnitOfWorkTipoDoc unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<TIPOS_DOC>> GetAllTiposDocumento()
        {
            return await _unitOfWork.TipoDocRepository.GetAllTiposDocumento();
        }
    }
}
