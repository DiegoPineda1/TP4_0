using CocheraTp.Models;
using CocheraTp.Servicios.TiposDocServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTipoDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocController : ControllerBase
    {
        private readonly ITipoDocService _tipoDocService;

        public TipoDocController(ITipoDocService tipoDocService)
        {
            _tipoDocService = tipoDocService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TIPOS_DOC>>> GetAllTiposDocumento()
        {
            try
            {
                var tiposDocumento = await _tipoDocService.GetAllTiposDocumento();
                if (tiposDocumento == null || tiposDocumento.Count == 0)
                {
                    return NotFound("No se encontraron tipos de documentos.");
                }
                return Ok(tiposDocumento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los tipos de documentos: {ex.Message}");
            }
        }

    }
}
