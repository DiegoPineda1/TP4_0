using CocheraTp.Models;
using CocheraTp.Servicios.ModeloServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiModelos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;

        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MODELO>>> GetAllModelos()
        {
            try
            {
                var modelos = await _modeloService.GetAllModelos();
                if (modelos == null || !modelos.Any())
                {
                    return NotFound("La lista de modelos está vacía o no existe");
                }
                return Ok(modelos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la lista de modelos");
            }
        }

        [HttpGet("buscar/{idMarca}")]
        public async Task<ActionResult<IEnumerable<MODELO>>> GetModelosByMarca(int idMarca)
        {
            try
            {
                var modelos = await _modeloService.GetAllByMarca(idMarca);
                if (modelos == null || !modelos.Any())
                {
                    return NotFound($"No se encontraron modelos para la marca con ID {idMarca}");
                }
                return Ok(modelos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al buscar modelos por ID de marca");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GuardarModelo([FromBody] MODELO modelo)
        {
            try
            {
                if (modelo == null || string.IsNullOrWhiteSpace(modelo.descripcion))
                {
                    return BadRequest("El modelo debe tener una descripción válida.");
                }

                var resultado = await _modeloService.GuardarModelo(modelo);
                if (resultado)
                {
                    return Ok("Modelo guardado con éxito.");
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Error al guardar el modelo.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al guardar el modelo.");
            }
        }


    }
}
