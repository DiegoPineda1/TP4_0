using CocheraTp.Repository.CarpetaRepositoryLugar.UnitofWorkLugar;
using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.LugarServicio
{
    public class LugarService : ILugarService
    {
        private readonly IUnitOfWorkLugar _unitOfWork;
        public LugarService(IUnitOfWorkLugar unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //    public async Task<List<LUGARE>> GetAllLugares()
        //    {
        //        return await _unitOfWork.LugarRepository.GetAllLugares();
        //    }

        //    public async Task<List<LUGARE>> GetLugaresDisponibles()
        //    {
        //        return await _unitOfWork.LugarRepository.GetLugaresDisponibles();
        //    }

        //    public async Task<bool> UpdateLugar(string id)
        //    {
        //        var actualizado = await _unitOfWork.LugarRepository.UpdateLugar(id);
        //        if(actualizado)
        //        {
        //            await _unitOfWork.SaveChangesAsync();
        //            return true;
        //        }
        //        return false;
        //    }

        //}
    }
}

