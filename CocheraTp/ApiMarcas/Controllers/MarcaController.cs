using CocheraTp.Models;
using CocheraTp.Servicios.ClienteSevicio;
using CocheraTp.Servicios.MarcaServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ApiMarcas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MARCA>>> GetALLMarcas()
        {
            try
            {
                var marcas = await _marcaService.GetAllMarcas();
                if (marcas == null || !marcas.Any())
                {
                    return NotFound("La lista de marcas está vacía o no existe");
                }
                return Ok(marcas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la lista de marcas");
            }
        }

        //[HttpGet("buscar")]
        //public async Task<ActionResult<IEnumerable<MARCA>>> GetMarcasByNombre(string nombreMarca)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(nombreMarca))
        //        {
        //            return BadRequest("El nombre de la marca no puede estar vacío.");
        //        }

        //        var marcas = await _marcaService.GetAllByMarca(nombreMarca);
        //        if (marcas == null || !marcas.Any())
        //        {
        //            return NotFound($"No se encontraron marcas que coincidan con '{nombreMarca}'");
        //        }

        //        return Ok(marcas);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error al buscar marcas por nombre");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> GuardarMarca([FromBody] MARCA marca)
        {
            try
            {
                if (marca == null || string.IsNullOrWhiteSpace(marca.nombre_marca))
                {
                    return BadRequest("La marca debe tener un nombre válido.");
                }

                var resultado = await _marcaService.GuardarMarca(marca);

                if (resultado)
                {
                    return Ok("Marca guardada con éxito.");
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Error al guardar la marca.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al guardar la marca.");
            }
        }
    }
}
