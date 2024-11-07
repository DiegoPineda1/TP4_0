using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryDetalleFactura.Interfaces;
using CocheraTp.Servicios.FacturaServicio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController : ControllerBase
    {
        private readonly IDetalleFacturaRepository _service;
        public DetalleFacturaController(IDetalleFacturaRepository service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<DETALLE_FACTURA>> CreateFactura([FromBody] DETALLE_FACTURA factura)
        {

            if (await _service.Create(factura) == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<DETALLE_FACTURA>> UpdateFactura([FromBody] int id, [FromQuery] DETALLE_FACTURA df)
        {
            if (await _service.Update(id, df) == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult<DETALLE_FACTURA>> DeleteFactura([FromQuery] int id)
        {
            if (await _service.DeleteById(id) == true)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
