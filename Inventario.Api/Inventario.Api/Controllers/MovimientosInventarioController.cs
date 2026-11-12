using Inventario.Api.Data;
using Inventario.Api.DTOs;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosInventarioController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public MovimientosInventarioController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoInventario>>> GetMovimientos()
        {
            var movimientos = await _context.MovimientosInventario.AsNoTracking().ToListAsync();
            return Ok(movimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoInventario>> GetMovimiento(int id)
        {
            var movimiento = await _context.MovimientosInventario.AsNoTracking().FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (movimiento == null) return NotFound();
            return Ok(movimiento);
        }

        [HttpPost]
        public async Task<ActionResult<MovimientoInventario>> CreateMovimiento(MovimientoInventarioDto dto)
        {
            var movimiento = new MovimientoInventario
            {
                IdProducto = dto.IdProducto,
                IdBodega = dto.IdBodega,
                Tipo = dto.Tipo,
                Cantidad = dto.Cantidad,
                Fecha = DateTime.Now
            };

            _context.MovimientosInventario.Add(movimiento);
            await _context.SaveChangesAsync();
            return Ok(movimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovimiento(int id, MovimientoInventarioDto dto)
        {
            var movimiento = await _context.MovimientosInventario.FindAsync(id);
            if (movimiento == null) return NotFound();

            movimiento.IdProducto = dto.IdProducto;
            movimiento.IdBodega = dto.IdBodega;
            movimiento.Tipo = dto.Tipo;
            movimiento.Cantidad = dto.Cantidad;

            _context.Entry(movimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimiento(int id)
        {
            var movimiento = await _context.MovimientosInventario.FindAsync(id);
            if (movimiento == null) return NotFound();
            _context.MovimientosInventario.Remove(movimiento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
