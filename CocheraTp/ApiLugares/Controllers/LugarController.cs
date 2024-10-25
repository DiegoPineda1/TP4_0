using CocheraTp.Repository.CarpetaRepositoryLugar.UnitofWorkLugar;
using CocheraTp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ApiLugares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarController : ControllerBase
    {
        private readonly IUnitOfWorkLugar _unitOfWork;
        public LugarController(IUnitOfWorkLugar unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LUGARE>>> GetAll()
        {
            return await _unitOfWork.LugarRepository.GetAllLugares();
        }

        [HttpGet("disponibles")]
        public async Task<ActionResult<IEnumerable<LUGARE>>> GetLugaresDisponibles()
        {
            return await _unitOfWork.LugarRepository.GetLugaresDisponibles();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLugarEstado(int id, [FromBody] bool estaOcupado)
        {
            var actualizado = await _unitOfWork.LugarRepository.UpdateLugar(id, estaOcupado);

            if (!actualizado)
            {
                return NotFound();
            }

            return Ok("Estado del lugar actualizado con éxito.");
        }
    }
}
