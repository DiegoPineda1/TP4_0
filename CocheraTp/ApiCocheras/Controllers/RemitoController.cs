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
               

                var remitos = await _remitoServicio.GetAllRemito();

                var idExiste = remitos.Any(e => e.id_remito == id);
                if (!idExiste)
                {
                    return Ok("Id no existe");
                }
               
                var remito = await _remitoServicio.GetRemito(id);
                if (remito != null)
                {
                    return Ok(remito);
                }
                return Ok(false);
            }
            catch (Exception)
            {

                return  BadRequest();
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
                return BadRequest(false);
            }
            catch (Exception)
            {
                return BadRequest();
                
            }
        }
    }
}
