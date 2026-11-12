using Inventario.Api.Data;
using Inventario.Api.DTOs;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasStockController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public ReservasStockController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaStock>>> GetReservas()
        {
            var reservas = await _context.ReservasStock.AsNoTracking().ToListAsync();
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaStock>> GetReserva(int id)
        {
            var reserva = await _context.ReservasStock.AsNoTracking().FirstOrDefaultAsync(r => r.IdReserva == id);
            if (reserva == null) return NotFound();
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<ActionResult<ReservaStock>> CreateReserva(ReservaStockDto dto)
        {
            var reserva = new ReservaStock
            {
                IdProducto = dto.IdProducto,
                IdBodega = dto.IdBodega,
                Cantidad = dto.Cantidad,
                Estado = dto.Estado
            };

            _context.ReservasStock.Add(reserva);
            await _context.SaveChangesAsync();
            return Ok(reserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReserva(int id, ReservaStockDto dto)
        {
            var reserva = await _context.ReservasStock.FindAsync(id);
            if (reserva == null) return NotFound();

            reserva.IdProducto = dto.IdProducto;
            reserva.IdBodega = dto.IdBodega;
            reserva.Cantidad = dto.Cantidad;
            reserva.Estado = dto.Estado;

            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.ReservasStock.FindAsync(id);
            if (reserva == null) return NotFound();
            _context.ReservasStock.Remove(reserva);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
