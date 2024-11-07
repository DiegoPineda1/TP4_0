using CocheraTp.Models;
using CocheraTp.Servicios.AbonoServicio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAbonos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonoController : ControllerBase
    {
        public readonly IAbonoServicios _abonoServicios;
        public AbonoController(IAbonoServicios abonoServicios) { 
            _abonoServicios = abonoServicios;
        }
        // GET: api/<AbonoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ABONO>>> GetAbonos()
        {
            return await _abonoServicios.GetAllAbonos();
        }
    }
}
