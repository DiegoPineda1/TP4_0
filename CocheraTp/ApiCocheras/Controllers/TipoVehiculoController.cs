using CocheraTp.Models;
using CocheraTp.Servicios.TipoVehiculoService;
using Microsoft.AspNetCore.Mvc;

namespace ApiCocheras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVehiculoController : ControllerBase
    {
        private readonly ITipoVehiculoService _tipoVehService;

        public TipoVehiculoController(ITipoVehiculoService tipoVehService)
        {
            _tipoVehService = tipoVehService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TIPO_VEHICULO>>> GetAllTipoVehiculo()
        {
            try
            {
                var tipoVehiculos = await _tipoVehService.GetAllTipoVehiculo();
                if (tipoVehiculos == null || tipoVehiculos.Count == 0)
                {
                    return NotFound("No se encontraron tipo de vehículos.");
                }
                return Ok(tipoVehiculos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los tipos de vehículos: {ex.Message}");
            }
        }
    }
}
