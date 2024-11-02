using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryLugar.UnitofWorkLugar;
using CocheraTp.Repository.CarpetaRepositoryMarca.UnitOfWorkMarca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.MarcaServicio
{
    public class MarcaService : IMarcaService
    {
        private readonly IUnitOfWorkMarca _unitOfWork;
        public MarcaService(IUnitOfWorkMarca unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public async Task<List<MARCA>> GetAllByMarca(string nombreMarca)
        //{
        //    return await _unitOfWork.MarcaRepository.GetAllByMarca(nombreMarca);    
        //}

        public async Task<List<MARCA>> GetAllMarcas()
        {
            return await _unitOfWork.MarcaRepository.GetAllMarcas();
        }

        public async Task<bool> GuardarMarca(MARCA marca)
        {
            var agregado = await _unitOfWork.MarcaRepository.GuardarMarca(marca);
            if (agregado)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return true;
        }
    }
}
