using CocheraTp.Repository.CarpetaRepositoryCliente.unitofworkClientes;
using CocheraTp.Servicios.ClienteSevicio;
using CocheraTp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CocheraTp.Repository.CarpetaRepositoryCliente.DTOs;


namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteCotroller : ControllerBase
    {
        private readonly IClienteServicios _clienteServicios;

        public ClienteCotroller(IClienteServicios clienteServicios)
        {
            _clienteServicios = clienteServicios;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDtoOut>>> GetClientesALL()
        {
            try
            {
                var clientes = await _clienteServicios.GetAllClientesDto();
                if (clientes == null || !clientes.Any())
                {
                    return NotFound("La lista de clientes está vacía o no existe");
                }
                return Ok(clientes);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la lista de clientes");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDtoOut>> GetClienteID(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El ID no puede ser menor o igual a 0");
                }
                var cliente = await _clienteServicios.GetClienteByIdDto(id);
                if (cliente == null)
                {
                    return NotFound("El cliente no existe");
                }
                return Ok(cliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el cliente");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, CLIENTE cliente)
        {
            try
            {
                if (id != cliente.id_cliente)
                {
                    return BadRequest("El ID no coincide con el cliente");
                }
                if (!ValidarCampos(cliente))
                {
                    return BadRequest("Los campos no pueden ser nulos");
                }
                var actualizado = await _clienteServicios.UpdateCliente(id, cliente);
                if (!actualizado)
                {
                    return NotFound("El cliente no existe");
                }
                return Ok($"Cliente con ID {id} actualizado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el cliente");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostCliente(CLIENTE cliente)
        {
            try
            {
                if (!ValidarCampos(cliente) || cliente.id_cliente != 0)
                {
                    return BadRequest("Campos no válidos o ID distinto de 0");
                }
                await _clienteServicios.CreateCliente(cliente);
                return Ok("Cliente agregado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el cliente");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El ID no puede ser menor o igual a 0");
                }
                var cliente = await _clienteServicios.GetClienteByIdDto(id);
                if (cliente == null)
                {
                    return NotFound("El cliente no existe");
                }
                await _clienteServicios.DeleteCliente(id);
                return Ok("Cliente eliminado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el cliente");
            }
        }

        private bool ValidarCampos(CLIENTE cliente)
        {
            return cliente != null &&
                   !string.IsNullOrEmpty(cliente.nombre) &&
                   !string.IsNullOrEmpty(cliente.apellido) &&
                   !string.IsNullOrEmpty(cliente.nro_documento) &&
                   !string.IsNullOrEmpty(cliente.telefono) &&
                   !string.IsNullOrEmpty(cliente.e_mail);
        }
    }
}
