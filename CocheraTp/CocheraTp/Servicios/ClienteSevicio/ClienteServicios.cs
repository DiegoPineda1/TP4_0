using CocheraTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocheraTp.Repository.CarpetaRepositoryCliente.unitofworkClientes;

namespace CocheraTp.Servicios.ClienteSevicio
{
    public class ClienteServicios : IClienteServicios
    {
        private readonly IUnitOfWorkCliente _unitOfWork;
        public ClienteServicios(IUnitOfWorkCliente unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateCliente(CLIENTE cliente)
        {
            var agregado = await _unitOfWork.ClienteRepository.CreateCliente(cliente);
            if (agregado)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> DeleteCliente(int id)
        {
           var eliminado = await _unitOfWork.ClienteRepository.DeleteCliente(id);
            if (eliminado)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<CLIENTE>> GetAllClientes()
        {
            return await _unitOfWork.ClienteRepository.GetAllClientes();
        }
        public async Task<CLIENTE> GetClienteById(int id)
        {
            return await _unitOfWork.ClienteRepository.GetClienteById(id);
        }
        public async Task<bool> UpdateCliente(int id, CLIENTE clienteActualizado)
        {
            var actualizado = await _unitOfWork.ClienteRepository.UpdateCliente(id, clienteActualizado);
            if (actualizado)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
