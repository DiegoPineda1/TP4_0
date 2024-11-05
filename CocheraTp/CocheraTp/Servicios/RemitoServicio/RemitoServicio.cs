using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryRemito.Interfaces;
using CocheraTp.Repository.CarpetaRepositoryRemito.UnitOfWorkRemito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.RemitoServicio
{
    public class RemitoServicio : IRemitoServicio
    {
        private readonly IUnitOfWorkRemito _unitOfWorkRemito;

        public RemitoServicio(IUnitOfWorkRemito unitOfWorkRemito)
        {
            _unitOfWorkRemito  = unitOfWorkRemito;
        }

        public async Task<bool> AddRemito(REMITO remito)
        {
            var agregado = await _unitOfWorkRemito.RepostoryRemito.AddRemito(remito);
            if(agregado)
            {
                await _unitOfWorkRemito.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<REMITO>> GetAllRemito()
        {
            return await _unitOfWorkRemito.RepostoryRemito.GetAllRemito();
        }

        public async Task<REMITO> GetRemito(int id)
        {
            return await _unitOfWorkRemito.RepostoryRemito.GetRemito(id);
        }
    }

}
