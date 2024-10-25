using CocheraTp.Repository.CarpetaRepositoryCliente.unitofworkClientes;
using CocheraTp.Servicios.ClienteSevicio;
using CocheraTp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteCotroller : ControllerBase
    {
        private readonly IClienteServicios _clienteServicios;
        public ClienteCotroller(IClienteServicios IClienteServicios)
        {
            _clienteServicios = IClienteServicios;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLIENTE>>> GetClientes()
        {
            try
            {
                if (_clienteServicios.GetAllClientes == null)
                {
                    return NotFound("La lista No existe");
                }
                //if (_clienteServicios.GetAllClientes().Result.Count == 0)
                //{
                //    return NotFound("La lista De cliente esta vacia");
                //}
                return Ok(await _clienteServicios.GetAllClientes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la lista de clientes");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CLIENTE>> GetCliente(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("El id no puede ser 0");
                }
                var cliente = await _clienteServicios.GetClienteById(id);
                if (cliente == null)
                {
                    return NotFound("El Cliete no existe");
                }
                return cliente;
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
                    return BadRequest("El id no coincide con el cliente");
                }
                if(!validarCampos(cliente))
                {
                    return BadRequest("Los campos no pueden ser nulos");
                }
                var actualizado = await _clienteServicios.UpdateCliente(id, cliente);
                if (!actualizado)
                {
                    return NotFound("El cliente no existe");
                }
                return Ok(id + " " + "Actualizado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el cliente");
            }
            
        }
        [HttpPost]
        public async Task<ActionResult<CLIENTE>> PostCliente(CLIENTE cliente)
        {
            try
            {
                if(!validarCampos(cliente))
                {
                    return BadRequest("Los campos no pueden ser nulos");
                }
                if(cliente.id_cliente != 0)
                {
                    return BadRequest("El id no puede ser distinto de 0");
                }
                if(cliente.id_cliente == 0  || cliente.id_iva_condicion == 0 || cliente.id_tipo_doc == 0)
                {
                    return BadRequest("Los id no pueden ser 0");
                }
                await _clienteServicios.CreateCliente(cliente);
                return Ok("Se Agrego Correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el cliente");
                throw;
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest("El id no puede ser 0");
                }
                var existe = await _clienteServicios.GetClienteById(id);
                if(existe == null)
                {
                    return NotFound("El cliente no existe");
                }
                await _clienteServicios.DeleteCliente(id);
                return Ok("Cliente eliminado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el cliente");
                throw;
            }
            
        }
        private bool validarCampos(CLIENTE cliente)
        {
            if (cliente == null)
            {
                return false;
            }
            if (cliente.nombre == null || cliente.nombre == "")
            {
                return false;
            }
            if (cliente.apellido == null || cliente.apellido == "")
            {
                return false;
            }
            
            if (cliente.nro_documento == null || cliente.nro_documento == "")
            {
                return false;
            }
            if (cliente.telefono == null || cliente.telefono == "")
            {
                return false;
            }
            if (cliente.e_mail == null || cliente.e_mail == "")
            {
                return false;
            }
            return true;
        }
    }
}
