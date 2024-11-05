using CocheraTp.Models;
using CocheraTp.Servicios.FormaPagoServicio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFormaPago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagoController : ControllerBase
    {
        private readonly IFormaPagoService _formaPagoService;

        public FormaPagoController(IFormaPagoService formaPagoService)
        {
            _formaPagoService = formaPagoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FORMAS_DE_PAGO>>> GetAllFormaPago()
        {
            try
            {
                var formaPagos = await _formaPagoService.GetAllFormaPago();
                if (formaPagos == null | formaPagos.Count == 0)
                {
                    return NotFound("No se encontraron forma de pagos.");
                }
                return Ok(formaPagos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener las formas de pago: {ex.Message}");
            }
        }
    }
}
