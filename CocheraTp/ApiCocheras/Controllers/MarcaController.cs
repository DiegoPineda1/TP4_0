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
                    return BadRequest();
                }
                return Ok(marcas);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<MARCA>> GuardarMarca(MARCA marca)
        {
            try
            {
                var resultado = await _marcaService.GuardarMarca(marca);
                if (resultado)
                {
                    return Ok(true);
                }
                return BadRequest(false);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}