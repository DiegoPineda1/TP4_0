using CocheraTp.Repository.CarpetaRepositoryLugar.UnitofWorkLugar;
using CocheraTp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CocheraTp.Servicios.LugarServicio;


namespace ApiLugares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarController : ControllerBase
    {
        private readonly ILugarService _service;
        public LugarController(ILugarService iservicio)
        {
            _service = iservicio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LUGARE>>> GetAll()
        {
            try
            {
                return await _service.GetAllLugares();
            }
            catch (Exception)
            {

                return null;
            }
        }

        [HttpGet("disponibles")]
        public async Task<ActionResult<IEnumerable<LUGARE>>> GetLugaresDisponibles()
        {
            try
            {
                return await _service.GetLugaresDisponibles();
            }
            catch (Exception)
            {

                return Ok(new List<LUGARE>());
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLugarEstado(string id)
        {
            try
            {
                var actualizado = await _service.UpdateLugar(id);

                if (!actualizado)
                {
                    return NotFound();
                }

                return Ok("Estado del lugar actualizado con éxito.");
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Ocurrió un error al actualizar el estado del lugar." });
            }
        }
    }
}
