using CocheraTp.Repository.CarpetaRepositoryFactura.UnitOfWorkFactura;
using CocheraTp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IUnitOfWorkFactura _unitOfWork;
        public FacturaController(IUnitOfWorkFactura unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FACTURA>>> GetFacturas()
        {
            return await _unitOfWork.FacturaRepository.GetAll();
        }
    }
}
