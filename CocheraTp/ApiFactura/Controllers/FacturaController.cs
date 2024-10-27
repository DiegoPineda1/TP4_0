using CocheraTp.Repository.CarpetaRepositoryFactura.UnitOfWorkFactura;
using CocheraTp.Models;
using Microsoft.AspNetCore.Mvc;
using CocheraTp.Servicios.FacturaServicio;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _service;
        public FacturaController(IFacturaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FACTURA?>>> GetFacturas()
        {
            return await _service.GetAllFacturas();
        }

        [HttpGet("By ID")]
        public async Task<ActionResult<FACTURA?>> GetFacturaByID([FromQuery] int id)
        {
            return await _service.GetFacturaById(id);
        }

        [HttpPost]
        public async Task<ActionResult<FACTURA>> CreateFactura([FromBody] FACTURA factura)
        {

            if (await _service.CreateFactura(factura) == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<FACTURA>> UpdateFactura([FromBody] int id, [FromQuery] FACTURA f)
        {
            if (await _service.UpdateFactura(id, f) == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult<FACTURA>> DeleteFactura([FromQuery] int id)
        {
            if(await _service.DeleteFactura(id) == true)
            {
                return Ok();
            }
            return BadRequest();
        }


    }
}
