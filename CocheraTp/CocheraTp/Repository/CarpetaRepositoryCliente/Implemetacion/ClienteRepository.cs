
using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryCliente.DTOs;
using CocheraTp.Repository.CarpetaRepositoryCliente.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryCliente.Implemetacion
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly db_cocherasContext _context;
        public ClienteRepository(db_cocherasContext db_CocherasContext)
        {
            _context = db_CocherasContext;
        }

        public async Task<bool> CreateCliente(CLIENTE cliente)
        {
            await _context.CLIENTEs.AddAsync(cliente);
            return true;
        }

        public async Task<bool> DeleteCliente(int id)
        {
            var cliente = await _context.CLIENTEs.FindAsync(id);
            if (cliente != null)
            {
                _context.CLIENTEs.Remove(cliente);
                return true;
            }
            return false;
        }

        public async Task<List<ClienteDtoOut>> GetAllClientesDto()
        {
            return await _context.CLIENTEs
                .Select(c => new ClienteDtoOut
                {
                    id_cliente = c.id_cliente,
                    nombre = c.nombre,
                    apellido = c.apellido,
                    Tipo_doc = c.id_tipo_docNavigation.descripcion,
                    nro_documento = c.nro_documento,
                    direccion = c.direccion,
                    telefono = c.telefono,
                    e_mail = c.email,
                    Iva = c.id_iva_condicionNavigation.descripcion

                }).ToListAsync();
        }

        public async Task<CLIENTE> GetClienteById(int id)
        {
            return await _context.CLIENTEs.FindAsync(id);
        }
        public async Task<ClienteDtoOut> GetClienteByIdDto(string documento)
        {
            return await _context.CLIENTEs
                .Where(c => c.nro_documento == documento)
                .Select(c => new ClienteDtoOut
                {
                    id_cliente = c.id_cliente,
                    nombre = c.nombre,
                    apellido = c.apellido,
                    Tipo_doc = c.id_tipo_docNavigation.descripcion,
                    nro_documento = c.nro_documento,
                    direccion = c.direccion,
                    telefono = c.telefono,
                    e_mail = c.email,
                    Iva = c.id_iva_condicionNavigation.descripcion

                }).FirstOrDefaultAsync();

        }





        public async Task<bool> UpdateCliente(int id, CLIENTE clienteActualizado)
        {
            var cliente = await _context.CLIENTEs.FindAsync(id);
            if (cliente != null)
            {
                _context.Entry(cliente).CurrentValues.SetValues(clienteActualizado);
                return true;
            }
            return false;
        }
    }
}
