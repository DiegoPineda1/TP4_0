using CocheraTp.Models;
using CocheraTp.Servicios.RemitoServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRemito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemitoController : ControllerBase
    {
        private readonly IRemitoServicio _remitoServicio;

        public RemitoController(IRemitoServicio remitoServicio)
        {
            _remitoServicio = remitoServicio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<REMITO>> GetRemito(int id)
        {
            try
            {
                return await _remitoServicio.GetRemito(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        [HttpPost]
        public async Task<ActionResult<REMITO>> AddRemito(REMITO remito)
        {
            try
            {
                var agregado = await _remitoServicio.AddRemito(remito);
                if (agregado)
                {
                    return Ok(true);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
                
            }
        }
    }
}
