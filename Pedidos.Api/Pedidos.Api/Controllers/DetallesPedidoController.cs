using Pedidos.Api.Data;
using Pedidos.Api.DTOs;
using Pedidos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidoController : ControllerBase
    {
        private readonly PedidosDbContext _context;

        public DetallesPedidoController(PedidosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetalles()
        {
            var detalles = await _context.DetallesPedido.AsNoTracking().ToListAsync();
            return Ok(detalles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetalle(int id)
        {
            var detalle = await _context.DetallesPedido.AsNoTracking().FirstOrDefaultAsync(d => d.IdDetalle == id);
            if (detalle == null) return NotFound();
            return Ok(detalle);
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> CreateDetalle(DetallePedidoDto dto)
        {
            var detalle = new DetallePedido
            {
                IdPedido = dto.IdPedido,
                IdProducto = dto.IdProducto,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario
            };

            _context.DetallesPedido.Add(detalle);
            await _context.SaveChangesAsync();
            return Ok(detalle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDetalle(int id, DetallePedidoDto dto)
        {
            var detalle = await _context.DetallesPedido.FindAsync(id);
            if (detalle == null) return NotFound();

            detalle.IdPedido = dto.IdPedido;
            detalle.IdProducto = dto.IdProducto;
            detalle.Cantidad = dto.Cantidad;
            detalle.PrecioUnitario = dto.PrecioUnitario;

            _context.Entry(detalle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalle(int id)
        {
            var detalle = await _context.DetallesPedido.FindAsync(id);
            if (detalle == null) return NotFound();
            _context.DetallesPedido.Remove(detalle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
