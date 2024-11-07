using CocheraTp.Models;
using CocheraTp.Servicios.CondicionesIVAServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCondicionesIVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionesIVAController : ControllerBase
    {
        private readonly ICondicionesIVAService _condicionesIVAService;

        public CondicionesIVAController(ICondicionesIVAService condicionesIVAService)
        {
            _condicionesIVAService = condicionesIVAService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IVA_CONDICIONE>>> GetAllCondiciones()
        {
            try
            {
                var condiciones = await _condicionesIVAService.GetAllCondiciones();
                if (condiciones == null || condiciones.Count == 0)
                {
                    return BadRequest();
                }
                return Ok(condiciones);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
