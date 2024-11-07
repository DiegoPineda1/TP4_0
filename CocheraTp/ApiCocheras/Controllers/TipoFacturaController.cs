using CocheraTp.Models;
using CocheraTp.Servicios.TipoFacServicio;
using Microsoft.AspNetCore.Mvc;

namespace ApiCocheras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoFacturaController : ControllerBase
    {
        private readonly ITipoFacService _tipoFacService;

        public TipoFacturaController(ITipoFacService tipoFacService)
        {
            _tipoFacService = tipoFacService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TIPO_FACTURA>>> GetAllTipoFactura()
        {
            try
            {
                var tipoFacturas = await _tipoFacService.GetAllTipoFactura();
                if (tipoFacturas == null || tipoFacturas.Count == 0)
                {
                    return NotFound("No se encontraron tipo de facturas.");
                }
                return Ok(tipoFacturas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los tipo de facturas: {ex.Message}");
            }
        }
    }
}
