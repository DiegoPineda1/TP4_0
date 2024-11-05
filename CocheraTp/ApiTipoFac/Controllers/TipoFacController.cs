using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryTipoFactura.Interfaces;
using CocheraTp.Servicios.TipoFacServicio;
using CocheraTp.Servicios.UsuarioServicio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTipoFac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoFacController : ControllerBase
    {
        private readonly ITipoFacService _tipoFacService;

        public TipoFacController(ITipoFacService tipoFacService)
        {
            _tipoFacService = tipoFacService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TIPO_FACTURA>>> GetAllTipoFactura()
        {
            try
            {
                var tipoFacturas = await _tipoFacService.GetAllTipoFactura();
                if (tipoFacturas == null | tipoFacturas.Count == 0)
                {
                    return NotFound("No se encontraron tipo de facturas.");
                }
                return Ok(tipoFacturas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los tipo de factura: {ex.Message}");
            }
        }
    }
}
