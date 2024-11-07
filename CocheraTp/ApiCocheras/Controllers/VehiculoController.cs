using CocheraTp.Servicios.VehiculoServicio;
using CocheraTp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVehiculo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoServicio _vehiculoServicio;
        public VehiculoController(IVehiculoServicio vehiculoServicio)
        {
            _vehiculoServicio = vehiculoServicio;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VEHICULO>>> GetVehiculos()
        {
            return await _vehiculoServicio.GetAllVehiculos();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VEHICULO>> GetVehiculo(int id)
        {
            var vehiculo = await _vehiculoServicio.GetVehiculoById(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return vehiculo;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, VEHICULO vehiculo)
        {
            if (id != vehiculo.id_vehiculo)
            {
                return BadRequest();
            }
            var actualizado = await _vehiculoServicio.UpdateVehiculo(id, vehiculo);
            if (!actualizado)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<VEHICULO>> PostVehiculo(VEHICULO vehiculo)
        {
            await _vehiculoServicio.CreateVehiculo(vehiculo);
            return CreatedAtAction("GetVehiculo", new { id = vehiculo.id_vehiculo }, vehiculo);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var eliminado = await _vehiculoServicio.DeleteVehiculo(id);
            if (!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
