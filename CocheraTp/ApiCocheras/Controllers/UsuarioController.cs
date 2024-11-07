using CocheraTp.Models;
using CocheraTp.Servicios.UsuarioServicio;
using Microsoft.AspNetCore.Mvc;

namespace ApiCocheras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<USUARIO>>> GetAllUsuario()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllUsuario();
                if (usuarios == null || usuarios.Count == 0)
                {
                    return NotFound("No se encontraron usuarios.");
                }
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los usuarios: {ex.Message}");
            }
        }
    }
}
