using CocheraTp.Repository.CarpetaRepositoryFactura.UnitOfWorkFactura;
using CocheraTp.Models;
using Microsoft.AspNetCore.Mvc;
using CocheraTp.Servicios.FacturaServicio;
using Microsoft.EntityFrameworkCore;
using CocheraTp.Servicios.DetalleFacturaServicio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _serviceF;
        private readonly IDetalleFacturaServicio _serviceDF;

        public FacturaController(IFacturaService serviceF, IDetalleFacturaServicio serviceDF)
        {
            _serviceF = serviceF;
            _serviceDF = serviceDF;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FACTURA?>>> GetFacturas()
        {
            return await _serviceF.GetAllFacturas();
        }

        [HttpGet("By ID")]
        public async Task<ActionResult<FACTURA?>> GetFacturaByID([FromQuery] int id)
        {
            return await _serviceF.GetFacturaById(id);
        }

        [HttpGet("by-patente/{patente}")]
        public async Task<ActionResult<FACTURA>> GetFacturaByPatente(string patente)
        {
            if (string.IsNullOrEmpty(patente))
            {
                return BadRequest("La patente no puede estar vacía.");
            }

            var factura = await _serviceF.GetFacturaByPatente(patente);

            if (factura == null)
            {
                return NotFound($"No se encontró ninguna factura asociada a la patente {patente}");
            }

            return Ok(factura);
        }

        [HttpPost]
        public async Task<ActionResult<FACTURA?>> CreateFactura([FromBody] FACTURA factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (factura.DETALLE_FACTURAs == null || !factura.DETALLE_FACTURAs.Any())
            {
                return BadRequest("La factura debe tener al menos un detalle.");
            }

            factura.fecha = DateTime.Now;

            var detalle = factura.DETALLE_FACTURAs.First();

            switch (detalle.id_abono)
            {
                case 1:
                    detalle.precio = 100;
                    detalle.descuento = 0;
                    break;
                case 2:
                    detalle.precio = 150;
                    detalle.descuento = 0;
                    break;
                case 3:
                    detalle.precio = 200;
                    detalle.descuento = 0.30m;
                    detalle.precio = detalle.precio * detalle.descuento;
                    break;
                default:
                    detalle.precio = detalle.precio;
                    break;
            }

            var facturaCreada = await _serviceF.CreateFactura(factura);

            if (facturaCreada != null)
            {
                return Ok(facturaCreada);
            }

            return BadRequest("Error al crear la factura.");
        }

        [HttpPut]
        public async Task<ActionResult<FACTURA>> UpdateFactura([FromBody] int idFacturaExistente, [FromBody] FACTURA facturaActualizada)
        {
            var facturaExistente = await _serviceF.GetFacturaById(idFacturaExistente);
            if (facturaExistente == null)
            {
                return NotFound("Factura no encontrada");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (facturaActualizada.DETALLE_FACTURAs == null || !facturaActualizada.DETALLE_FACTURAs.Any())
            {
                return BadRequest("La factura debe tener al menos un detalle.");
            }

            facturaExistente.fecha = facturaActualizada.fecha;
            facturaExistente.id_cliente = facturaActualizada.id_cliente;
            facturaExistente.id_tipo_factura = facturaActualizada.id_tipo_factura;

            var detallesExistentes = await _serviceDF.GetDetallesByFacturaId(idFacturaExistente);

            foreach (var detalle in facturaActualizada.DETALLE_FACTURAs)
            {
                var detalleExistente = detallesExistentes.FirstOrDefault(d => d.id_detalle_factura == detalle.id_detalle_factura);
                if (detalleExistente != null)
                {
                    detalleExistente.precio = detalle.precio;
                    detalleExistente.descuento = detalle.descuento;
                    detalleExistente.recargo = detalle.recargo;
                }
                else
                {
                    detalle.id_factura = idFacturaExistente;
                    await _serviceDF.CreateDetalleFactura(detalle);
                }
            }

            var result = await _serviceF.UpdateFactura(idFacturaExistente, facturaExistente);

            if (result)
            {
                return Ok("Factura y detalles actualizados correctamente.");
            }

            return BadRequest("Error al actualizar la factura.");
        }

        [HttpDelete]
        public async Task<ActionResult<FACTURA>> DeleteFactura([FromQuery] int id)
        {
            var factura = await _serviceF.GetFacturaById(id);

            if (factura == null)
            {
                return NotFound("Factura no encontrada");
            }

            var detalles = await _serviceDF.GetDetallesByFacturaId(id);
            foreach (var detalle in detalles)
            {
                await _serviceDF.DeleteDetalleFactura(detalle.id_detalle_factura);
            }

            var result = await _serviceF.DeleteFactura(id);

            if (result)
            {
                return Ok("Factura y detalles eliminados correctamente");
            }

            return BadRequest("Error al eliminar la factura");
        }
    }
}
