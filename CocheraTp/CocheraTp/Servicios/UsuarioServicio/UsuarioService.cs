using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryUsuario.UnitOfWorkUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.UsuarioServicio
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWorkUsuario _unitOfWork;

        public UsuarioService(IUnitOfWorkUsuario unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<USUARIO>> GetAllUsuario()
        {
            return await _unitOfWork.UsuarioRepository.GetAllUsuario();
        }
    }
}
