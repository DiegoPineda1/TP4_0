using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryModelo.UnitOfWorkModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.ModeloServicio
{
    public class ModeloService : IModeloService
    {
        private readonly IUnitOfWorkModelo _unitOfWork;

        public ModeloService(IUnitOfWorkModelo unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<MODELO>> GetAllByMarca(int idMarca)
        {
            return await _unitOfWork.ModeloRepository.GetAllByMarca(idMarca);
        }

        public async Task<List<MODELO>> GetAllModelos()
        {
            return await _unitOfWork.ModeloRepository.GetAllModelos();
        }

        public async Task<bool> GuardarModelo(MODELO modelo)
        {
            var agregado = await _unitOfWork.ModeloRepository.GuardarModelo(modelo);
            if (agregado)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return agregado;
        }
    }
}
